using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class TrendingTagsClient : ApiClient
    {
        public TrendingTagsClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task<TrendingTags> IllustAsync(string filter = "")
        {
            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add("filter", filter);
            return await PixivClient.GetAsync<TrendingTags>("https://app-api.pixiv.net/v1/trending-tags/illust", parameters);
        }

        /// <summary>
        ///     Get trending tags of novels.
        ///     Note: This API returns *illustrations*.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<TrendingTags> NovelAsync(string filter = "")
        {
            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add("filter", filter);
            return await PixivClient.GetAsync<TrendingTags>("https://app-api.pixiv.net/v1/trending-tags/novel", parameters);
        }
    }
}