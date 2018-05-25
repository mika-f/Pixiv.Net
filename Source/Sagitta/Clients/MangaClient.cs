using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Models;

namespace Sagitta.Clients
{
    /// <summary>
    ///     マンガ関連 API
    /// </summary>
    public class MangaClient : ApiClient
    {
        internal MangaClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     おすすめのマンガ一覧を取得します。
        /// </summary>
        /// <param name="bookmarkIllustIds">TODO</param>
        /// <param name="includeRankingIllusts">ランキング上位のイラストをレスポンスに含むか</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> RecommendedAsync(List<long> bookmarkIllustIds = null, bool includeRankingIllusts = false, string filter = "")
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (bookmarkIllustIds != null)
                parameters.Add(new KeyValuePair<string, string>("bookmark_illust_ids", string.Join(",", bookmarkIllustIds)));
            if (includeRankingIllusts)
                parameters.Add(new KeyValuePair<string, string>("include_ranking_illusts", true.ToString()));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/manga/recommended", parameters).Stay();
        }
    }
}