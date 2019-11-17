using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Enums;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1.User
{
    public class BookmarkTagsClient : ApiClient
    {
        internal BookmarkTagsClient(PixivClient client) : base(client, "/v1/user/bookmark-tags") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<BookmarkTagCollection> IllustAsync(Restrict restrict, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<BookmarkTagCollection>("/illust", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<BookmarkTagCollection> NovelAsync(Restrict restrict, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<BookmarkTagCollection>("/novel", parameters).Stay();
        }
    }
}