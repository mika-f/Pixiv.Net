using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class NovelMarkerClient : ApiClient
    {
        public NovelMarkerClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task AddAsync(int novelId, int page)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));
            Ensure.GreaterThanZero(page, nameof(page));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString()),
                new KeyValuePair<string, string>("page", page.ToString())
            };
            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v1/novel/marker/add", parameters);
        }

        public async Task DeleteAsync(int novelId)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString())
            };
            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v1/novel/marker/delete", parameters);
        }
    }
}