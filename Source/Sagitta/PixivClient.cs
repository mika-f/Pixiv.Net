using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Sagitta.Exceptions;

namespace Sagitta
{
    public class PixivClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly HttpClient _httpClient;

        public string AccessToken { get; internal set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="clientSecret">Client Secret</param>
        public PixivClient(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;

            // 2017/02/13
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("App-OS-Version", "10.2.1");
            _httpClient.DefaultRequestHeaders.Add("App-OS", "ios");
            _httpClient.DefaultRequestHeaders.Add("App-Version", "6.5.2");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "PixivIOSApp/6.5.2 (iOS 10.2.1; iPhone7,2)");
        }

        internal async Task<T> GetAsync<T>(string url, Dictionary<string, string> parameters, bool requireAuth = true)
        {
            if (requireAuth && string.IsNullOrWhiteSpace(AccessToken))
                throw new PixivException("No access token available. Need authentication first.");
            if (requireAuth)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            url += "?" + string.Join("&", parameters.Select(w => $"{w.Key}={Uri.EscapeDataString(w.Value)}"));
            var response = await _httpClient.GetAsync(url);
            HandleErrors(response);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        internal async Task<T> PostAsync<T>(string url, Dictionary<string, string> parameters, bool requireAuth = true)
        {
            if (requireAuth && string.IsNullOrWhiteSpace(AccessToken))
                throw new PixivException("No access token available. Need authentication first.");
            if (requireAuth)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var content = new FormUrlEncodedContent(parameters);
            var response = await _httpClient.PostAsync(url, content);
            HandleErrors(response);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        private void HandleErrors(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new AuthorizationException(response);
            response.EnsureSuccessStatusCode();
        }
    }
}