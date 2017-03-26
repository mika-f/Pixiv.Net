using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class TrendingTagsClient : ApiClient
    {
        public TrendingTagsClient(PixivClient pixivClient) : base(pixivClient) {}

        public Task<TrendingTags> IllustAsync(string filter = "")
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            return PixivClient.GetAsync<TrendingTags>("https://app-api.pixiv.net/v1/trending-tags/illust", parameters);
        }

        /// <summary>
        ///     Get trending tags of novels.
        ///     Note: This API returns *illustrations*.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Task<TrendingTags> NovelAsync(string filter = "")
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            return PixivClient.GetAsync<TrendingTags>("https://app-api.pixiv.net/v1/trending-tags/novel", parameters);
        }
    }
}