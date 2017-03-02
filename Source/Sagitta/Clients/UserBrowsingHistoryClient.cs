using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class UserBrowsingHistoryClient : ApiClient
    {
        public UserBrowsingHistoryClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task<IllustsRoot> IllustsAsync(int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v1/user/browsing-history/illusts", parameters);
        }

        public async Task AddIllustAsync(IEnumerable<int> illustIds)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(illustIds.Select(w => new KeyValuePair<string, string>("illust_ids[]", w.ToString())));

            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v2/user/browsing-history/illust/add", parameters);
        }

        public async Task<NovelsRoot> NovelsAsync(int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<NovelsRoot>("https://app-api.pixiv.net/v1/user/browsing-history/novels", parameters);
        }

        public async Task AddNovelAsync(IEnumerable<int> novelIds)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(novelIds.Select(w => new KeyValuePair<string, string>("novel_ids[]", w.ToString())));

            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v2/user/browsing-history/novel/add", parameters);
        }
    }
}