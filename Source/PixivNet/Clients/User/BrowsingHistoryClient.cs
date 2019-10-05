using System.Threading.Tasks;

using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.User
{
    /// <summary>
    ///     閲覧履歴関連 API
    /// </summary>
    public class BrowsingHistoryClient : ApiClient
    {
        /// <summary>
        ///     閲覧履歴 (イラスト) 関連 API へのアクセサー
        /// </summary>
        public IllustClient Illust { get; }

        /// <summary>
        ///     閲覧履歴 (小説) 関連 API へのアクセサー
        /// </summary>
        public NovelClient Novel { get; }

        /// <inheritdoc />
        internal BrowsingHistoryClient(PixivClient pixivClient) : base(pixivClient)
        {
            Illust = new IllustClient(pixivClient);
            Novel = new NovelClient(pixivClient);
        }

        /// <summary>
        ///     イラストの閲覧履歴を取得します。
        /// </summary>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> IllustsAsync()
        {
            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/user/browsing-history/illusts").Stay();
        }

        /// <summary>
        ///     小説の閲覧履歴を取得します。
        /// </summary>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> NovelsAsync()
        {
            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/user/browsing-history/novels").Stay();
        }
    }
}