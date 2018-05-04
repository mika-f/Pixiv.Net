using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients.Illust
{
    public class BookmarkClient : ApiClient
    {
        /// <inheritdoc />
        internal BookmarkClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     指定したイラストをブックマークに追加します。
        /// </summary>
        /// <param name="illustId">イラスト ID</param>
        /// <param name="restrict">公開制限</param>
        /// <param name="tags">タグ</param>
        public async Task AddAsync(long illustId, Restrict restrict = Restrict.Public, string[] tags = null)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameter())
            };
            if (tags?.Length > 0)
                parameters.Add(new KeyValuePair<string, string>("tags[]", string.Join(",", tags)));

            await PixivClient.PostAsync("https://app-api.pixiv.net/v2/illust/bookmark/add", parameters).Stay();
        }

        /// <summary>
        ///     指定したイラストに対してのブックマーク情報を取得します。
        /// </summary>
        /// <param name="illustId">イラスト ID</param>
        /// <returns>
        ///     <see cref="BookmarkDetail" />
        /// </returns>
        public async Task<BookmarkDetail> DetailAsync(long illustId)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };

            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v2/illust/bookmark/detail", parameters).Stay();
            return response["bookmark_detail"].ToObject<BookmarkDetail>();
        }

        /// <summary>
        ///     指定したイラストをブックマークしているユーザーを取得します。
        /// </summary>
        /// <param name="illustId">イラスト ID</param>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="UserCollection" />
        /// </returns>
        public async Task<UserCollection> UsersAsync(long illustId, long offset = 0)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<UserCollection>("https://app-api.pixiv.net/v1/illust/bookmark/users", parameters).Stay();
        }
    }
}