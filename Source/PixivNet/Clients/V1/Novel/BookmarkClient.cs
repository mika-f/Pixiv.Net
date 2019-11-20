using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1.Novel
{
    public class BookmarkClient : ApiClient
    {
        internal BookmarkClient(PixivClient client) : base(client, "/v1/novel/bookmark") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<UserCollection> UsersAsync(long novelId, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("novel_id", novelId)
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<UserCollection>("/users", parameters).Stay();
        }
    }
}