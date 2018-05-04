using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients.User
{
    /// <summary>
    ///     ユーザーのブックマーク関連 API
    /// </summary>
    public class BookmarksClient : ApiClient
    {
        /// <inheritdoc />
        internal BookmarksClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     指定したユーザーのイラストブックマークを取得します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="restrict">公開制限 (自分以外は Public のみ取得可能)</param>
        /// <param name="tag">絞り込みタグ (自分に対してのみ使用可能)</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> IllustAsync(long userId, Restrict restrict = Restrict.Public, string tag = null, string filter = null)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameter = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameter())
            };
            if (!string.IsNullOrWhiteSpace(tag))
                parameter.Add(new KeyValuePair<string, string>("tag", tag));
            if (!string.IsNullOrWhiteSpace(filter))
                parameter.Add(new KeyValuePair<string, string>("filter", filter));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/user/bookmarks/illust", parameter).Stay();
        }

        /// <summary>
        ///     指定したユーザーの小説ブックマークを取得します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="restrict">公開制限 (自分以外は Public のみ取得可能)</param>
        /// <param name="tag">絞り込みタグ (自分に対してのみ使用可能)</param>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> NovelAsync(long userId, Restrict restrict = Restrict.Public, string tag = null)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameter = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameter())
            };
            if (!string.IsNullOrWhiteSpace(tag))
                parameter.Add(new KeyValuePair<string, string>("tag", tag));

            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/user/bookmarks/novel", parameter).Stay();
        }
    }
}