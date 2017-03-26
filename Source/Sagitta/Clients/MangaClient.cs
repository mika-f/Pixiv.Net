using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class MangaClient : ApiClient
    {
        public MangaClient(PixivClient pixivClient) : base(pixivClient) {}

        public Task<IllustCollection> RecommendedAsync(bool includeRankingIllusts = false, string filter = "", int maxBookmarkId = 0, int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("include_ranking_illusts", includeRankingIllusts.ToString().ToLower())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (maxBookmarkId > 0)
                parameters.Add(new KeyValuePair<string, string>("max_bookmark_id", maxBookmarkId.ToString()));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/manga/recommended", parameters);
        }
    }
}