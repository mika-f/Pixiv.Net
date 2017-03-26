using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class UserBookmarksClient : ApiClient
    {
        public UserBookmarksClient(PixivClient pixivClient) : base(pixivClient) {}

        public Task<IllustCollection> IllustAsync(int userId, string filter = "", int maxBookmarkId = 0, Restrict restrict = Restrict.Public,
                                                  string tag = "")
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
            if (maxBookmarkId > 0)
                parameters.Add(new KeyValuePair<string, string>("max_bookmark_id", maxBookmarkId.ToString()));
            if (!string.IsNullOrWhiteSpace(tag))
                parameters.Add(new KeyValuePair<string, string>("tag", tag));

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/user/bookmarks/illust", parameters);
        }

        public Task<NovelCollection> NovelAsync(int userId, int maxBookmarkId = 0, Restrict restrict = Restrict.Public, string tag = "")
        {
            Ensure.GreaterThanZero(userId, nameof(userId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (maxBookmarkId > 0)
                parameters.Add(new KeyValuePair<string, string>("max_bookmark_id", maxBookmarkId.ToString()));
            if (!string.IsNullOrWhiteSpace(tag))
                parameters.Add(new KeyValuePair<string, string>("tag", tag));

            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/user/bookmarks/novel", parameters);
        }
    }
}