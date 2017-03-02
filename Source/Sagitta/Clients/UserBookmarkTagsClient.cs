using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class UserBookmarkTagsClient : ApiClient
    {
        public UserBookmarkTagsClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task<BookmarkTags> IllustAsync(Restrict restrict = Restrict.Public, int offset = 0)
        {
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<BookmarkTags>("https://app-api.pixiv.net/v1/user/bookmark-tags/illust", parameters);
        }

        public async Task<BookmarkTags> NovelAsync(Restrict restrict = Restrict.Public, int offset = 0)
        {
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<BookmarkTags>("https://app-api.pixiv.net/v1/user/bookmark-tags/novel", parameters);
        }
    }
}