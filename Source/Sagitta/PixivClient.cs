using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Sagitta.Clients;
using Sagitta.Exceptions;
using Sagitta.Extensions;
using Sagitta.Models;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Sagitta
{
    public class PixivClient
    {
        private readonly HttpClient _httpClient;
        public static string AppVersion => "6.6.2";
        public static string OsVersion => "10.2.1";
        internal string ClientId { get; }
        internal string ClientSecret { get; }
        internal static List<KeyValuePair<string, string>> EmptyParameter => new List<KeyValuePair<string, string>>();

        public string AccessToken { get; internal set; }
        public string RefreshToken { get; internal set; }

        /// <summary>
        ///     Access application information API.
        /// </summary>
        public ApplicationInfoClient ApplicationInfo { get; private set; }

        /// <summary>
        ///     Access illustration API.
        /// </summary>
        public IllustClient Illust { get; private set; }

        /// <summary>
        ///     Access manga API.
        /// </summary>
        public MangaClient Manga { get; private set; }

        /// <summary>
        ///     Access mute API.
        /// </summary>
        public MuteClient Mute { get; private set; }

        /// <summary>
        ///     Access notification API.
        /// </summary>
        public NotificationClient Notification { get; private set; }

        /// <summary>
        ///     Access novel API.
        /// </summary>
        public NovelClient Novel { get; private set; }

        /// <summary>
        ///     Access authorization API.
        /// </summary>
        public AuthorizationClient OAuth { get; private set; }

        /// <summary>
        ///     Access search API.
        /// </summary>
        public SearchClient Search { get; private set; }

        /// <summary>
        ///     Access pixiv Spotlight (pixivision) API.
        /// </summary>
        public SpotlightClient Spotlight { get; private set; }

        /// <summary>
        ///     Access trending tags API.
        /// </summary>
        public TrendingTagsClient TrendingTags { get; private set; }

        /// <summary>
        ///     Access ugoira API.
        /// </summary>
        public UgoiraClient Ugoira { get; private set; }

        /// <summary>
        ///     Access user API.
        /// </summary>
        public UserClient User { get; private set; }

        /// <summary>
        ///     Access walkthrough API.
        /// </summary>
        public WalkthroughClient Walkthrough { get; private set; }

        /// <summary>
        ///     Get pixiv images.
        /// </summary>
        public FileClient File { get; private set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="clientSecret">Client Secret</param>
        public PixivClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;

            // 2017/03/20
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("App-OS-Version", OsVersion);
            _httpClient.DefaultRequestHeaders.Add("App-OS", "ios");
            _httpClient.DefaultRequestHeaders.Add("App-Version", AppVersion);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"PixivIOSApp/{AppVersion} (iOS {OsVersion}; iPhone7,2)");

            ApplicationInfo = new ApplicationInfoClient(this);
            Illust = new IllustClient(this);
            Manga = new MangaClient(this);
            Mute = new MuteClient(this);
            Notification = new NotificationClient(this);
            Novel = new NovelClient(this);
            OAuth = new AuthorizationClient(this);
            Search = new SearchClient(this);
            Spotlight = new SpotlightClient(this);
            TrendingTags = new TrendingTagsClient(this);
            Ugoira = new UgoiraClient(this);
            User = new UserClient(this);
            Walkthrough = new WalkthroughClient(this);
            File = new FileClient(this);
        }

        internal async Task<T> GetAsync<T>(string url, IEnumerable<KeyValuePair<string, string>> parameters, bool requireAuth = true)
        {
            if (requireAuth && string.IsNullOrWhiteSpace(AccessToken))
                throw new PixivException("No access token available. Need authentication first.");
            if (requireAuth)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            if (parameters.Any())
                url += "?" + string.Join("&", parameters.Select(w => $"{w.Key}={Uri.EscapeDataString(w.Value)}"));
            var response = await _httpClient.GetAsync(url);
            HandleErrors(response);

            var obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().Stay());
            if (obj is Cursorable)
                (obj as Cursorable).PixivClient = this;
            return obj;
        }

        internal async Task<T> PostAsync<T>(string url, IEnumerable<KeyValuePair<string, string>> parameters, bool requireAuth = true)
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

        private static void HandleErrors(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(response);

                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(response);
            }
            response.EnsureSuccessStatusCode();
        }
    }
}