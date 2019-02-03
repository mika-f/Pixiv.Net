using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    /// <summary>
    ///     生放送関連 API
    /// </summary>
    public class LiveClient : ApiClient
    {
        /// <inheritdoc />
        internal LiveClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     生放送の一覧を取得します。
        /// </summary>
        /// <param name="type">取得する配信情報</param>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="LiveCollection" />
        /// </returns>
        public async Task<LiveCollection> ListAsync(ListType type, long offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("list_type", type.ToParameter())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<LiveCollection>("https://app-api.pixiv.net/v1/live/list", parameters).Stay();
        }

        /// <summary>
        ///     指定された配信の詳細情報を取得します。
        /// </summary>
        /// <param name="liveId">配信 ID</param>
        /// <returns>
        ///     <see cref="LiveResponse{Live}" />
        /// </returns>
        public async Task<LiveResponse<Live>> ShowAsync(long liveId)
        {
            Ensure.GreaterThanZero(liveId, nameof(liveId));

            return await PixivClient.GetAsync<LiveResponse<Live>>($"https://sketch.pixiv.net/api/lives/{liveId}").Stay();
        }

        /// <summary>
        ///     指定された配信のチャットを取得します。
        /// </summary>
        /// <param name="liveId">配信 ID</param>
        /// <returns>
        ///     <see cref="LiveResponse{LiveChat}" />
        /// </returns>
        public async Task<LiveResponse<LiveChat>> ChatAsync(long liveId)
        {
            Ensure.GreaterThanZero(liveId, nameof(liveId));

            return await PixivClient.GetAsync<LiveResponse<LiveChat>>($"https://sketch.pixiv.net/api/lives/{liveId}/chat").Stay();
        }
    }
}