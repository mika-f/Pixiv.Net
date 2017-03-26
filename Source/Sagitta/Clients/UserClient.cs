// ReSharper disable UnusedAutoPropertyAccessor.Global

using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class UserClient : ApiClient
    {
        public UserBookmarksClient Bookmarks { get; }
        public UserBookmarkTagsClient BookmarkTags { get; }
        public UserBrowsingHistoryClient BrowsingHistory { get; }
        public UserFollowClient Follow { get; }

        public UserClient(PixivClient pixivClient) : base(pixivClient)
        {
            Bookmarks = new UserBookmarksClient(pixivClient);
            BookmarkTags = new UserBookmarkTagsClient(pixivClient);
            BrowsingHistory = new UserBrowsingHistoryClient(pixivClient);
            Follow = new UserFollowClient(pixivClient);
        }

        public Task<UserDetail> DetailAsync(int userId)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            return PixivClient.GetAsync<UserDetail>("https://app-api.pixiv.net/v1/user/detail", parameters);
        }

        public Task<UserPreviewCollection> FollowerAsync(int userId, string filter = "", int offset = 0)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/follower", parameters);
        }

        public Task<UserPreviewCollection> FollowingAsync(int userId, Restrict restrict = Restrict.Public, string filter = "", int offset = 0)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/following", parameters);
        }

        public Task<IllustCollection> IllustsAsync(IllustType type, int userId, string filter = "", int offset = 0)
        {
            Ensure.InvalidEnumValue(type == IllustType.Ugoira, nameof(type));
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("type", type.ToParameterStr()),
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/user/illusts", parameters);
        }

        // TODO: Fix response type.
        public Task<UserPreviewCollection> ListAsync(string filter = "", int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            return PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v2/user/list", parameters);
        }

        public Task<NovelCollection> NovelsAsync(int userId, int offset = 0)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/user/novels", parameters);
        }

        public Task<UserPreviewCollection> RecommendedAsync(string filter = "", int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/recommended", parameters);
        }

        public Task<UserPreviewCollection> RelatedAsync(int seedUserId, string filter = "")
        {
            Ensure.GreaterThanZero(seedUserId, nameof(seedUserId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("seed_user_id", seedUserId.ToString())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));

            return PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/related", parameters);
        }

        // me/state
        public async Task<UserState> MyStateAsync()
        {
            var response = await PixivClient.GetAsync<StateResponse>("https://app-api.pixiv.net/v1/user/me/state", PixivClient.EmptyParameter).Stay();
            return response?.UserState;
        }

        public Task<UserPreviewCollection> MypixivAsync(int userId, int offset = 0)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/user/mypixiv", parameters);
        }
    }
}