using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using Sagitta.Extensions;

namespace Sagitta.Clients
{
    public class FileClient : ApiClient
    {
        private readonly HttpClient _httpClient;

        public FileClient(PixivClient pixivClient) : base(pixivClient)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("App-OS-Version", PixivClient.OsVersion);
            _httpClient.DefaultRequestHeaders.Add("App-OS", "ios");
            _httpClient.DefaultRequestHeaders.Add("App-Version", PixivClient.AppVersion);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"PixivIOSApp/{PixivClient.AppVersion} (iOS {PixivClient.OsVersion}; iPhone7,2)");
            _httpClient.DefaultRequestHeaders.Referrer = new Uri("https://app-api.pixiv.net/");
        }

        public async Task<Stream> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url).Stay();
            return await response.Content.ReadAsStreamAsync().Stay();
        }
    }
}