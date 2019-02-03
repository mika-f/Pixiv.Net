using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Clients.User;
using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    /// <summary>
    ///     ユーザー関連 API
    /// </summary>
    public class UserClient : ApiClient
    {
        /// <summary>
        ///     ブックマーク関連 API へのアクセサー
        /// </summary>
        public BookmarksClient Bookmarks { get; }

        /// <summary>
        ///     ブックマークタグ関連 API へのアクセサー
        /// </summary>
        public BookmarkTagsClient BookmarkTags { get; }

        /// <summary>
        ///     閲覧履歴関連 API へのアクセサー
        /// </summary>
        public BrowsingHistoryClient BrowsingHistory { get; }

        /// <summary>
        ///     認証ユーザー関連 API へのアクセサー
        /// </summary>
        public MeClient Me { get; }

        /// <summary>
        ///     認証ユーザーのプロフィール関連 API へのアクセサー
        /// </summary>
        public ProfileClient Profile { get; }

        /// <summary>
        ///     作業環境関連 API へのアクセサー
        /// </summary>
        public WorkspaceClient Workspace { get; }

        /// <summary>
        ///     フォロー関連 API へのアクセサー
        /// </summary>
        public FollowClient Follow { get; }

        /// <inheritdoc />
        internal UserClient(PixivClient pixivClient) : base(pixivClient)
        {
            Bookmarks = new BookmarksClient(pixivClient);
            BookmarkTags = new BookmarkTagsClient(pixivClient);
            BrowsingHistory = new BrowsingHistoryClient(pixivClient);
            Me = new MeClient(pixivClient);
            Profile = new ProfileClient(pixivClient);
            Workspace = new WorkspaceClient(pixivClient);
            Follow = new FollowClient(pixivClient);
        }

        /// <summary>
        ///     指定したユーザーの詳細情報を取得します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="UserDetail" />
        /// </returns>
        public async Task<UserDetail> DetailAsync(long userId, string filter = "")
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, object>>{new KeyValuePair<string, object>("user_id", userId)};
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<UserDetail>("https://app-api.pixiv.net/v1/user/detail", parameters).Stay();
        }

        /// <summary>
        ///     おすすめユーザーを取得します。
        /// </summary>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="UserPreviewCollection" />
        /// </returns>
        public async Task<UserPreviewCollection> RecommendedAsync(long offset = 0, string filter = "")
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/recommended", parameters).Stay();
        }

        /// <summary>
        ///     指定したユーザーが投稿したイラスト・マンガを取得します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="type">イラストもしくはマンガ</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> IllustsAsync(long userId, IllustType type, long offset = 0, string filter = "")
        {
            Ensure.GreaterThanZero(userId, nameof(userId));
            Ensure.InvalidEnumValue(type == IllustType.Ugoira, nameof(type));

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("type", type.ToParameter())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/user/illusts", parameters).Stay();
        }

        /// <summary>
        ///     指定したユーザーの小説を取得します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> NovelsAsync(long userId, long offset = 0)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, object>>{new KeyValuePair<string, object>("user_id", userId)};
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/user/novels", parameters).Stay();
        }

        /// <summary>
        ///     指定したユーザーがフォローしているユーザーを取得します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="restrict">公開制限</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="UserPreviewCollection" />
        /// </returns>
        public async Task<UserPreviewCollection> FollowingAsync(long userId, Restrict restrict = Restrict.Public, long offset = 0, string filter = "")
        {
            Ensure.GreaterThanZero(userId, nameof(userId));
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("restrict", restrict.ToParameter())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/following", parameters).Stay();
        }

        /// <summary>
        ///     指定したユーザーをフォローしているユーザーを取得します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="UserPreviewCollection" />
        /// </returns>
        public async Task<UserPreviewCollection> FollowerAsync(long userId, long offset = 0, string filter = "")
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, object>>{new KeyValuePair<string, object>("user_id", userId)};
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/follower", parameters).Stay();
        }

        /// <summary>
        ///     指定したユーザーのマイピクを取得します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="UserPreviewCollection" />
        /// </returns>
        public async Task<UserPreviewCollection> MypixivAsync(long userId, long offset = 0, string filter = "")
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, object>>{new KeyValuePair<string, object>("user_id", userId)};
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/mypixiv", parameters).Stay();
        }

        // TODO: /v2/user/list, What is this?
    }
}