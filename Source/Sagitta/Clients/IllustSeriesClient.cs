using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Extensions;
using Pixiv.Helpers;
using Pixiv.Models;

namespace Pixiv.Clients
{
    /// <summary>
    ///     イラストシリーズ関連 API
    /// </summary>
    public class IllustSeriesClient : ApiClient
    {
        /// <inheritdoc />
        internal IllustSeriesClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     シリーズについての情報を取得します。
        /// </summary>
        /// <param name="illustId">イラスト ID</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustSeries" />
        /// </returns>
        public async Task<IllustSeries> IllustAsync(long illustId, string filter = "")
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("illust_id", illustId) };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<IllustSeries>("https://app-api.pixiv.net/v1/illust-series/illust", parameters).Stay();
        }
    }
}