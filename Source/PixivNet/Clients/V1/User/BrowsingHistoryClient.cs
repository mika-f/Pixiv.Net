using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1.User
{
    public class BrowsingHistoryClient : ApiClient
    {
        internal BrowsingHistoryClient(PixivClient client) : base(client, "/v1/user/browsing-history") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> IllustAsync(long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<IllustCollection>("/illusts", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> NovelAsync(long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<NovelCollection>("/novels", parameters).Stay();
        }
    }
}