using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sagitta.Clients
{
    public class ImageClient : ApiClient
    {
        private readonly HttpClient _httpClient;

        public ImageClient(PixivClient pixivClient) : base(pixivClient)
        {
            _httpClient = new HttpClient();
        }

        public async Task<Stream> GetAsync(string url)
        {
            _httpClient.DefaultRequestHeaders.Referrer = new Uri("https://app-api.pixiv.net/");
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStreamAsync();
        }
    }
}