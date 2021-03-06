﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Pixiv.Clients.Auth;
using Pixiv.Clients.IO;
using Pixiv.Clients.V1;
using Pixiv.Exceptions;
using Pixiv.Extensions;

using IllustV1Client = Pixiv.Clients.V1.IllustClient;
using IllustV2Client = Pixiv.Clients.V2.IllustClient;
using SearchV1Client = Pixiv.Clients.V1.SearchClient;
using SearchV2Client = Pixiv.Clients.V2.SearchClient;
using UserV1Client = Pixiv.Clients.V1.UserClient;
using UserV2Client = Pixiv.Clients.V2.UserClient;

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
        public FileClient File { get; }
        public IllustSeriesClient IllustSeries { get; }
        public IllustV1Client IllustV1 { get; }
        public IllustV2Client IllustV2 { get; }
        public MangaClient Manga { get; }
        public MuteClient Mute { get; }
        public NotificationClient Notification { get; }
        public NovelClient Novel { get; }
        public PPointClient PPoint { get; }
        public SearchV1Client SearchV1 { get; }
        public SearchV2Client SearchV2 { get; }
        public SpotlightClient Spotlight { get; }
        public TrendingTagsClient TrendingTags { get; }
        public UserV1Client UserV1 { get; }
        public UserV2Client UserV2 { get; }
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

            ApplicationInfo = new ApplicationInfoClient(this);
            Authentication = new AuthenticationClient(this);
            File = new FileClient(this);
            IllustSeries = new IllustSeriesClient(this);
            IllustV1 = new IllustV1Client(this);
            IllustV2 = new IllustV2Client(this);
            Manga = new MangaClient(this);
            Mute = new MuteClient(this);
            Notification = new NotificationClient(this);
            Novel = new NovelClient(this);
            PPoint = new PPointClient(this);
            SearchV1 = new SearchV1Client(this);
            SearchV2 = new SearchV2Client(this);
            Spotlight = new SpotlightClient(this);
            TrendingTags = new TrendingTagsClient(this);
            UserV1 = new UserV1Client(this);
            UserV2 = new UserV2Client(this);
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

        internal async Task<JObject> GetAsync(string url, bool isRequiredAuthentication, bool isRequiredReferrer, List<KeyValuePair<string, object>>? parameters = null)
        {
            if (parameters?.Count > 0)
                url += "?" + string.Join("&", parameters.Select(w => $"{w.Key}={Uri.EscapeDataString(AsStringValue(w.Value))}"));
            ApplyPixivHeaders(isRequiredAuthentication, isRequiredReferrer);

            var response = await _httpClient.GetAsync(url).Stay();
            HandleErrors(response);

            return JObject.Parse(await response.Content.ReadAsStringAsync().Stay());
        }

        internal async Task<Stream> GetAsStreamAsync(string url, bool isRequiredAuthentication, bool isRequiredReferrer)
        {
            ApplyPixivHeaders(isRequiredAuthentication, isRequiredReferrer);

            var response = await _httpClient.GetAsync(url).Stay();
            HandleErrors(response);

            return await response.Content.ReadAsStreamAsync().Stay();
        }

        internal async Task<JObject> PostAsync(string url, bool isRequiredAuthentication, bool isRequiredReferrer, IEnumerable<KeyValuePair<string, object>>? parameters)
        {
            using var content = new FormUrlEncodedContent(parameters?.Select(w => new KeyValuePair<string, string>(w.Key, AsStringValue(w.Value))));
            ApplyPixivHeaders(isRequiredAuthentication, isRequiredReferrer);

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

        [SuppressMessage("Security", "CA5351:破られた暗号アルゴリズムを使用しない", Justification = "<保留中>")]
        private void ApplyPixivHeaders(bool isRequiredAuthentication, bool appendReferrer)
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

            if (isRequiredAuthentication)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            if (appendReferrer)
                _httpClient.DefaultRequestHeaders.Referrer = new Uri("https://app-api.pixiv.net/");
        }

        internal virtual DateTimeOffset GetCurrentDate()
        {
            return new DateTimeOffset(DateTime.Now);
        }
    }
}