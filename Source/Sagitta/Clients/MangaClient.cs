using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class MangaClient : ApiClient
    {
        public MangaClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task<IllustsRoot> RecommendedAsync(bool includeRankingIllusts = false, string filter = "", int maxBookmarkId = 0, int offset = 0)
        {
            var parameters = new Dictionary<string, string>
            {
                {"include_ranking_illusts", includeRankingIllusts.ToString().ToLower()}
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add("filter", filter);
            if (maxBookmarkId > 0)
                parameters.Add("max_bookmark_id", maxBookmarkId.ToString());
            if (offset > 0)
                parameters.Add("offset", offset.ToString());
            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v1/manga/recommended", parameters);
        }
    }
}