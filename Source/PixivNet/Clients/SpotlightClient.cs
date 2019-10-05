using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients
{
    /// <summary>
    ///     Pixivision (旧 pixiv Spotlight) 関連 API
    /// </summary>
    public class SpotlightClient : ApiClient
    {
        /// <inheritdoc />
        internal SpotlightClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     指定したカテゴリーの Pixivision (旧 pixiv Spotlight) の記事一覧を取得します。
        /// </summary>
        /// <param name="category">カテゴリー</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="SpotlightArticleCollection" />
        /// </returns>
        public async Task<SpotlightArticleCollection> ArticlesAsync(string category = "all", long offset = 0, string filter = "")
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("category", category) };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<SpotlightArticleCollection>("https://app-api.pixiv.net/v1/spotlight/article", parameters).Stay();
        }
    }
}