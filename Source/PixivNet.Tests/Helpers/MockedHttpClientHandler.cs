using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Pixiv.Tests.Models;

namespace Pixiv.Tests.Helpers
{
    internal class MockedHttpClientHandler : HttpClientHandler
    {
        private readonly List<Cassette> _cassettes;
        private readonly string _fixturePath;
        private readonly List<string> _privateHeaders;

        public MockedHttpClientHandler(string fixturePath, List<string>? privateHeaders = null)
        {
            _fixturePath = fixturePath;
            _privateHeaders = privateHeaders ?? new List<string>();
            _cassettes = new List<Cassette>();

            // default private headers
            _privateHeaders.Add("Authorization");
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
            var cassette = new Cassette
            {
                Request = new CassetteRequest
                {
                    Uri = request.RequestUri,
                    Headers = request.Headers.ToDictionary(pair => pair.Key, pair => _privateHeaders.Contains(pair.Key) ? new List<string> { "**REDACTED**" } : pair.Value),
                    Body = request.Content == null ? "" : await request.Content.ReadAsStringAsync()
                },
                Response = new CassetteResponse
                {
                    StatusCode = response.StatusCode,
                    Headers = response.Headers.ToDictionary(pair => pair.Key, pair => _privateHeaders.Contains(pair.Key) ? new List<string> { "**REDACTED**" } : pair.Value),
                    Body = await response.Content.ReadAsStringAsync()
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
            _cassettes.AddRange(JsonSerializer.Deserialize<List<Cassette>>(sr.ReadToEnd()));
        }

        private void FlushFixturesToPath(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            using var sw = new StreamWriter(path);
            sw.WriteLine(JsonSerializer.Serialize(_cassettes));
        }
    }
}