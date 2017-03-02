// ReSharper disable UnusedAutoPropertyAccessor.Global

using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class UserClient : ApiClient
    {
        public UserBookmarksClient Bookmarks { get; private set; }
        public UserBookmarkTagsClient BookmarkTags { get; private set; }
        public UserBrowsingHistoryClient BrowsingHistory { get; private set; }
        public UserFollowClient Follow { get; private set; }

        public UserClient(PixivClient pixivClient) : base(pixivClient)
        {
            Bookmarks = new UserBookmarksClient(pixivClient);
            BookmarkTags = new UserBookmarkTagsClient(pixivClient);
            BrowsingHistory = new UserBrowsingHistoryClient(pixivClient);
            Follow = new UserFollowClient(pixivClient);
        }

        public async Task<UserDetail> DetailAsync(int userId)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            return await PixivClient.GetAsync<UserDetail>("https://app-api.pixiv.net/v1/user/detail", parameters);
        }

        public async Task<UserPreviewsRoot> FollowerAsync(int userId, string filter = "", int offset = 0)
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

            return await PixivClient.GetAsync<UserPreviewsRoot>("https://app-api.pixiv.net/v1/user/follower", parameters);
        }

        public async Task<UserPreviewsRoot> FollowingAsync(int userId, Restrict restrict = Restrict.Public, string filter = "", int offset = 0)
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

            return await PixivClient.GetAsync<UserPreviewsRoot>("https://app-api.pixiv.net/v1/user/following", parameters);
        }

        public async Task<IllustsRoot> IllustsAsync(IllustType type, int userId, string filter = "", int offset = 0)
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

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v1/user/illusts", parameters);
        }

        // TODO: Fix response type.
        public async Task<UserPreviewsRoot> ListAsync(string filter = "")
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            return await PixivClient.GetAsync<UserPreviewsRoot>("https://app-api.pixiv.net/v2/user/list", parameters);
        }

        public async Task<NovelsRoot> NovelsAsync(int userId, int offset = 0)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<NovelsRoot>("https://app-api.pixiv.net/v1/user/novels", parameters);
        }

        public async Task<UserPreviewsRoot> Recommended(string filter = "", int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<UserPreviewsRoot>("https://app-api.pixiv.net/v1/user/recommended", parameters);
        }

        public async Task<UserPreviewsRoot> Related(int seedUserId, string filter = "")
        {
            Ensure.GreaterThanZero(seedUserId, nameof(seedUserId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("seed_user_id", seedUserId.ToString())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));

            return await PixivClient.GetAsync<UserPreviewsRoot>("https://app-api.pixiv.net/v1/user/related", parameters);
        }

        // me/state
        public async Task<StateRoot> MyState()
        {
            return await PixivClient.GetAsync<StateRoot>("https://app-api.pixiv.net/v1/user/me/state", PixivClient.EmptyParameter);
        }

        public async Task<UserPreviewsRoot> Mypixiv(int userId, int offset = 0)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<UserPreviewsRoot>("https://app-api.pixiv.net/v1/user/mypixiv", parameters);
        }
    }
}