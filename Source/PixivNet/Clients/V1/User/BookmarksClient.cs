using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Enums;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1.User
{
    public class BookmarksClient : ApiClient
    {
        internal BookmarksClient(PixivClient client) : base(client, "/v1/user/bookmarks") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> IllustAsync(long userId, Restrict restrict = Restrict.Public, string? tag = null, long? maxBookmarkId = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };

            if (!string.IsNullOrWhiteSpace(tag))
                parameters.Add(new KeyValuePair<string, object>(nameof(tag), tag));
            if (maxBookmarkId.HasValue)
                parameters.Add(new KeyValuePair<string, object>("max_bookmark_id", maxBookmarkId));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<IllustCollection>("/illust", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> NovelAsync(long userId, Restrict restrict = Restrict.Public, string? tag = null, long? maxBookmarkId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };

            if (!string.IsNullOrWhiteSpace(tag))
                parameters.Add(new KeyValuePair<string, object>(nameof(tag), tag));
            if (maxBookmarkId.HasValue)
                parameters.Add(new KeyValuePair<string, object>("max_bookmark_id", maxBookmarkId));

            return await GetAsync<NovelCollection>("/novel", parameters).Stay();
        }
    }
}