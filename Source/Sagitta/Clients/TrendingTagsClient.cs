using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Models;

namespace Sagitta.Clients
{
    /// <summary>
    ///     トレンドタグ API
    /// </summary>
    public class TrendingTagsClient : ApiClient
    {
        /// <inheritdoc />
        internal TrendingTagsClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     イラストのトレンドタグ一覧を取得します。
        /// </summary>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IEnumerable{TrendingTag}" />
        /// </returns>
        public async Task<IEnumerable<TrendingTag>> IllustAsync(string filter = "")
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/trending-tags/illust", parameters).Stay();
            return response["trending_tags"].ToObject<IEnumerable<TrendingTag>>();
        }

        /// <summary>
        ///     小説のトレンドタグ一覧を取得します。
        /// </summary>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IEnumerable{TrendingTag}" />
        /// </returns>
        public async Task<IEnumerable<TrendingTag>> NovelAsync(string filter = "")
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/trending-tags/novel", parameters).Stay();
            return response["trending_tags"].ToObject<IEnumerable<TrendingTag>>();
        }
    }
}