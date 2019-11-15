using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Clients.V2.User;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V2
{
    public class UserClient : ApiClient
    {
        public BrowsingHistoryClient BrowsingHistory { get; }

        internal UserClient(PixivClient client) : base(client, "/v2/user")
        {
            BrowsingHistory = new BrowsingHistoryClient(client);
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<ApiResponse> ListAsync(string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<ApiResponse>("/list", parameters).Stay();
        }
    }
}