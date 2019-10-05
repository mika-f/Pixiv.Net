using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using Sagitta.Extensions;

namespace Sagitta.Clients
{
    /// <summary>
    ///     画像およびファイルへの間接的なアクセスを提供します。
    /// </summary>
    public class FileClient : ApiClient
    {
        private readonly HttpClient _httpClient;

        /// <inheritdoc />
        internal FileClient(PixivClient pixivClient) : base(pixivClient)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("App-OS-Version", PixivClient.OsVersion);
            _httpClient.DefaultRequestHeaders.Add("App-OS", "ios");
            _httpClient.DefaultRequestHeaders.Add("App-Version", PixivClient.AppVersion);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"PixivIOSApp/{PixivClient.AppVersion} (iOS {PixivClient.OsVersion}; iPhone11,2)");
            _httpClient.DefaultRequestHeaders.Referrer = new Uri("https://app-api.pixiv.net/");
        }

        /// <summary>
        ///     指定した URL の画像を取得します。
        ///     **Pixiv の画像およびうごイラなどの ZIP ファイルは、指定された方法以外で取得することは出来ません。**
        /// </summary>
        /// <param name="url">Pximg URL</param>
        /// <returns>バイナリ Stream</returns>
        public async Task<Stream> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url).Stay();
            return await response.Content.ReadAsStreamAsync().Stay();
        }
    }
}