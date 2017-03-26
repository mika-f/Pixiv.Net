using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class UserBrowsingHistoryClient : ApiClient
    {
        public UserBrowsingHistoryClient(PixivClient pixivClient) : base(pixivClient) {}

        public Task<IllustCollection> IllustsAsync(int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/user/browsing-history/illusts", parameters);
        }

        public async Task AddIllustAsync(IEnumerable<int> illustIds)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(illustIds.Select(w => new KeyValuePair<string, string>("illust_ids[]", w.ToString())));

            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v2/user/browsing-history/illust/add", parameters).Stay();
        }

        public Task<NovelCollection> NovelsAsync(int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/user/browsing-history/novels", parameters);
        }

        public async Task AddNovelAsync(IEnumerable<int> novelIds)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(novelIds.Select(w => new KeyValuePair<string, string>("novel_ids[]", w.ToString())));

            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v2/user/browsing-history/novel/add", parameters).Stay();
        }
    }
}