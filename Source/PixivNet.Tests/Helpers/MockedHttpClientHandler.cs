using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Pixiv.Tests.Models;

namespace Pixiv.Tests.Helpers
{
    internal class MockedHttpClientHandler : HttpClientHandler
    {
        private readonly List<Cassette> _cassettes;
        private readonly string _fixturePath;
        private readonly List<string> _privateHeaders;
        private readonly List<string> _privateParameters;
        private readonly List<string> _privateResponses;

        public MockedHttpClientHandler(string fixturePath, List<string>? privateHeaders = null, List<string>? privateParameters = null, List<string>? privateResponses = null)
        {
            _fixturePath = fixturePath;
            _privateHeaders = privateHeaders ?? new List<string>();
            _privateParameters = privateParameters ?? new List<string>();
            _privateResponses = privateResponses ?? new List<string>();
            _cassettes = new List<Cassette>();

            // default private keys
            _privateHeaders.Add("Authorization");
            _privateParameters.Add("username");
            _privateParameters.Add("password");
            _privateParameters.Add("client_id");
            _privateParameters.Add("client_secret");
            _privateResponses.Add("access_token");
            _privateResponses.Add("refresh_token");
            _privateResponses.Add("mail_address");
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (ShouldVerifyUsingFixture() || IsExistsFixture(request))
                return FetchResponseFromFixture(request);

            return await FetchResponseFromRealHttp(request, cancellationToken);
        }

        private async Task<HttpResponseMessage> FetchResponseFromRealHttp(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var cassette = new Cassette
            {
                Request = new CassetteRequest
                {
                    Uri = request.RequestUri,
                    Headers = request.Headers.ToDictionary(pair => pair.Key, pair => _privateHeaders.Contains(pair.Key) ? new List<string> { "**REDACTED**" } : pair.Value),
                    Body = request.Content == null ? "" : RedactPrivateParameters(await request.Content.ReadAsStringAsync())
                },
                Response = new CassetteResponse
                {
                    StatusCode = response.StatusCode,
                    Headers = response.Headers.ToDictionary(pair => pair.Key, pair => _privateHeaders.Contains(pair.Key) ? new List<string> { "**REDACTED**" } : pair.Value),
                    Body = RedactPrivateResponses(await response.Content.ReadAsStringAsync())
                }
            };
            _cassettes.Add(cassette);
            FlushFixturesToPath(_fixturePath);

            return response;
        }

        private HttpResponseMessage FetchResponseFromFixture(HttpRequestMessage request)
        {
            var cassette = _cassettes.Single(w => w.Request.Uri == request.RequestUri);
            var response = new HttpResponseMessage(cassette.Response.StatusCode)
            {
                Content = new StringContent(cassette.Response.Body)
            };

            foreach (var (name, value) in cassette.Response.Headers)
                response.Headers.Add(name, value);

            return response;
        }

        private bool ShouldVerifyUsingFixture()
        {
            return !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("CI"));
        }

        private bool IsExistsFixture(HttpRequestMessage request)
        {
            if (_cassettes.Count == 0)
                LoadFixturesFromPath(_fixturePath);
            return _cassettes.Any(w => w.Request.Uri == request.RequestUri);
        }

        private void LoadFixturesFromPath(string path)
        {
            if (!File.Exists(path))
                return;

            using var sr = new StreamReader(path);
            _cassettes.AddRange(JsonConvert.DeserializeObject<List<Cassette>>(sr.ReadToEnd()));
        }

        private void FlushFixturesToPath(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            using var sw = new StreamWriter(path);
            sw.WriteLine(JsonConvert.SerializeObject(_cassettes));
        }

        private string RedactPrivateParameters(string form)
        {
            var obj = form.Split("&").Select(w => (w.Split("=")[0], w.Split("=")[1]));
            var parameters = obj.Select(tuple => _privateParameters.Contains(tuple.Item1) ? $"{tuple.Item1}=**REDACTED**" : $"{tuple.Item1}={tuple.Item2}").ToList();

            return string.Join("&", parameters);
        }

        private string RedactPrivateResponses(string json)
        {
            JObject RecursiveRedact(JObject o)
            {
                foreach (var (key, value) in o)
                {
                    if (_privateResponses.Contains(key))
                        o[key] = "**REDACTED**";
                    if (value is JObject jsonObj)
                        o[key] = RecursiveRedact(jsonObj);
                }

                return o;
            }

            var obj = JObject.Parse(json);
            return RecursiveRedact(obj).ToString(Formatting.None);
        }
    }
}