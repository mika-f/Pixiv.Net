using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class MangaClient : ApiClient
    {
        internal MangaClient(PixivClient client) : base(client, "/v1/manga") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> RecommendedAsync(List<long> bookmarkIllustIds, bool includeRankingIllusts, string? filter = "for_ios", bool includePrivacyPolicy = true, long? maxBookmarkId = null, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("bookmark_illust_ids", string.Join(",", bookmarkIllustIds)),
                new KeyValuePair<string, object>("include_ranking_illusts", includeRankingIllusts),
                new KeyValuePair<string, object>("include_privacy_policy", includePrivacyPolicy)
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));
            if (maxBookmarkId.HasValue)
                parameters.Add(new KeyValuePair<string, object>("max_bookmark_id", maxBookmarkId.Value));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<IllustCollection>("/recommended", parameters).Stay();
        }
    }
}