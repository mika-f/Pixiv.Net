using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
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
        public async Task<LiveCollection> ListAsync(IllustType type, long offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("list_type", type.ToParameter())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<LiveCollection>("https://app-api.pixiv.net/v1/live/list", parameters).Stay();
        }
    }
}