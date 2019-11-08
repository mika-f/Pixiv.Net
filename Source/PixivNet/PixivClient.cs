using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Pixiv.Clients;
using Pixiv.Clients.Auth;
using Pixiv.Clients.V1;
using Pixiv.Exceptions;
using Pixiv.Extensions;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Pixiv
{
    /// <summary>
    ///     pixiv API client wrapper for .NET Standard 2.1.
    ///     You can access pixiv APIs using this class's instance.
    /// </summary>
    public class PixivClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        internal static string AppVersion => "7.7.7";
        internal static string OsVersion => "13.1.3";
        internal string ClientId { get; }
        internal string ClientSecret { get; }
        internal string ClientHash { get; }

        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public ApplicationInfoClient ApplicationInfo { get; }
        public AuthenticationClient Authentication { get; }
        public TrendingTagsClient TrendingTags { get; }
        public WalkthroughClient Walkthrough { get; }

        public PixivClient(string clientId, string clientSecret, string clientHash, HttpMessageHandler? handler = null)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            ClientHash = clientHash;

            _httpClient = handler != null ? new HttpClient(handler) : new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("App-OS-Version", OsVersion);
            _httpClient.DefaultRequestHeaders.Add("App-OS", "ios");
            _httpClient.DefaultRequestHeaders.Add("App-Version", AppVersion);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"PixivIOSApp/{AppVersion} (iOS {OsVersion}; iPhone11,2)");

            Application = new ApplicationInfoClient(this);
            Illust = new IllustClient(this);
            IllustSeries = new IllustSeriesClient(this);
            Live = new LiveClient(this);
            Manga = new MangaClient(this);
            Mute = new MuteClient(this);
            Notification = new NotificationClient(this);
            Novel = new NovelClient(this);
            Search = new SearchClient(this);
            Spotlight = new SpotlightClient(this);
            User = new UserClient(this);
            File = new FileClient(this);
            ApplicationInfo = new ApplicationInfoClient(this);
            Authentication = new AuthenticationClient(this);
            TrendingTags = new TrendingTagsClient(this);
            Walkthrough = new WalkthroughClient(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _httpClient?.Dispose();
        }

        ~PixivClient()
        {
            Dispose(false);
        }

        internal async Task<JObject> GetAsync(string url, bool isRequiredAuthentication, List<KeyValuePair<string, object>>? parameters = null)
        {
            if (parameters != null && parameters.Count > 0)
                url += "?" + string.Join("&", parameters.Select(w => $"{w.Key}={Uri.EscapeDataString(AsStringValue(w.Value))}"));
            ApplyPixivHeaders(isRequiredAuthentication);

            var response = await _httpClient.GetAsync(url).Stay();
            HandleErrors(response);

            return JObject.Parse(await response.Content.ReadAsStringAsync().Stay());
        }

        internal async Task<JObject> PostAsync(string url, bool isRequiredAuthentication, IEnumerable<KeyValuePair<string, object>>? parameters)
        {
            using var content = new FormUrlEncodedContent(parameters?.Select(w => new KeyValuePair<string, string>(w.Key, AsStringValue(w.Value))));
            ApplyPixivHeaders(isRequiredAuthentication);

            var response = await _httpClient.PostAsync(url, content).Stay();
            HandleErrors(response);
            return JObject.Parse(await response.Content.ReadAsStringAsync().Stay());
        }

        private static string AsStringValue<T>(T w)
        {
#pragma warning disable CA1308 // 文字列を大文字に標準化します
            return w is bool ? w.ToString().ToLowerInvariant() : w!.ToString();
#pragma warning restore CA1308 // 文字列を大文字に標準化します
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

                default:
                    response.EnsureSuccessStatusCode();
                    break;
            }
        }

        #region API Accessors

        // ReSharper disable MemberCanBePrivate.Global

        /// <summary>
        ///     アプリケーション情報関連 API へのアクセサー
        /// </summary>
        public ApplicationInfoClient Application { get; }

        /// <summary>
        ///     イラスト関連 API へのアクセサー
        /// </summary>
        public IllustClient Illust { get; }

        /// <summary>
        ///     イラストシリーズ関連 API へのアクセサー
        /// </summary>
        public IllustSeriesClient IllustSeries { get; }

        /// <summary>
        ///     生放送関連 API へのアクセサー
        /// </summary>
        public LiveClient Live { get; }

        /// <summary>
        ///     マンガ関連 API へのアクセサー
        /// </summary>
        public MangaClient Manga { get; }

        /// <summary>
        ///     ミュート関連 API へのアクセサー
        /// </summary>
        public MuteClient Mute { get; }

        /// <summary>
        ///     通知関連 API へのアクセサー
        /// </summary>
        public NotificationClient Notification { get; }

        /// <summary>
        ///     小説関連 API へのアクセサー
        /// </summary>
        public NovelClient Novel { get; }

        /// <summary>
        ///     検索関連 API へのアクセサー
        /// </summary>
        public SearchClient Search { get; }

        /// <summary>
        ///     Pixivision (旧 pixiv Spotlight)  関連 API へのアクセサー
        /// </summary>
        public SpotlightClient Spotlight { get; }

        /// <summary>
        ///     ユーザー関連 API へのアクセサー
        /// </summary>
        public UserClient User { get; }

        /// <summary>
        ///     Pixiv ファイル関連 API へのアクセサー
        /// </summary>
        public FileClient File { get; }

        // ReSharper restore MemberCanBePrivate.Global

        #endregion
        [SuppressMessage("Security", "CA5351:破られた暗号アルゴリズムを使用しない", Justification = "<保留中>")]
        private void ApplyPixivHeaders(bool isRequiredAuthentication)
        {
            // Add X-Client-Hash, X-Client-Time and Authorization Header for Pixiv Authorization Protocol
            if (!string.IsNullOrWhiteSpace(ClientHash))
            {
                // hash algorithm is quoted from https://github.com/akameco/pixiv-app-api/blob/8801410f518a216d8a646ea9db7eb4c451e60275/src/index.ts#L107-L126
                var localTime = GetCurrentDate().ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);

                _httpClient.DefaultRequestHeaders.Add("X-Client-Time", localTime);

                using var md5 = new MD5CryptoServiceProvider();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes($"{localTime}{ClientHash}"));
                md5.Clear();

                _httpClient.DefaultRequestHeaders.Add("X-Client-Hash", string.Concat(hash.Select(w => w.ToString("x2", null))));
            }

            if (isRequiredAuthentication && string.IsNullOrWhiteSpace(AccessToken))
                throw new InvalidOperationException();

            if (!string.IsNullOrWhiteSpace(AccessToken))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
        }

        internal virtual DateTimeOffset GetCurrentDate()
        {
            return new DateTimeOffset(DateTime.Now);
        }
    }
}