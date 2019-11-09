using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Clients.V2.Illust;
using Pixiv.Enum;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V2
{
    public class IllustClient : ApiClient
    {
        public BookmarkClient Bookmark { get; }
        
        internal IllustClient(PixivClient client) : base(client, "/v2/illust")
        {
            Bookmark = new BookmarkClient(client);
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<CommentCollection> CommentsAsync(long illustId, long? lastCommentId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("illust_id", illustId)
            };
            
            if (lastCommentId.HasValue)
                parameters.Add(new KeyValuePair<string, object>("last_comment_id", lastCommentId.Value));

            return await GetAsync<CommentCollection>("/comments", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> FollowAsync(Restrict restrict, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };
            
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<IllustCollection>("/follow", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> MypixivAsync(long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<IllustCollection>("/mypixiv", parameters).Stay();
        }
        
        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> RelatedAsync(long illustId, string? filter = "for_ios", long? offset = null, long[]? seedIllustIds = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("illust_id", illustId)
            };
            
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));
            if (seedIllustIds?.Length > 0)
                parameters.AddRange(seedIllustIds.Select(w => new KeyValuePair<string, object>("seed_illust_ids[]", w)));

            return await GetAsync<IllustCollection>("/related", parameters).Stay();
        }
    }
}