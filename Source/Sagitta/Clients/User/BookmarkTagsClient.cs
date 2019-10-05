using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients.User
{
    /// <summary>
    ///     ブックマークタグ関連 API
    /// </summary>
    public class BookmarkTagsClient : ApiClient
    {
        /// <inheritdoc />
        internal BookmarkTagsClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     指定した公開制限のブックマークで、イラストに対して付けたタグのリストを取得します。
        /// </summary>
        /// <param name="restrict">
        ///     公開制限
        /// </param>
        /// <returns>
        ///     <see cref="BookmarkTagCollection" />
        /// </returns>
        public async Task<BookmarkTagCollection> IllustAsync(Restrict restrict = Restrict.Public)
        {
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("restrict", restrict.ToParameter()) };
            return await PixivClient.GetAsync<BookmarkTagCollection>("https://app-api.pixiv.net/v1/user/bookmark-tags/illust", parameters).Stay();
        }

        /// <summary>
        ///     指定した公開制限のブックマークで、小説に対して付けたタグのリストを取得します。
        /// </summary>
        /// <param name="restrict">
        ///     公開制限
        /// </param>
        /// <returns>
        ///     <see cref="BookmarkTagCollection" />
        /// </returns>
        public async Task<BookmarkTagCollection> NovelAsync(Restrict restrict = Restrict.Public)
        {
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("restrict", restrict.ToParameter()) };
            return await PixivClient.GetAsync<BookmarkTagCollection>("https://app-api.pixiv.net/v1/user/bookmark-tags/novel", parameters).Stay();
        }
    }
}