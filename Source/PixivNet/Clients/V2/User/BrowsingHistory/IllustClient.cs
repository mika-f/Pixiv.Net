using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;

namespace Pixiv.Clients.V2.User.BrowsingHistory
{
    public class IllustClient : ApiClient
    {
        internal IllustClient(PixivClient client) : base(client, "/v2/user/browsing-history/illust") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task AddAsync(IEnumerable<long> illustIds)
        {
            var parameters = illustIds.Select(illustId => new KeyValuePair<string, object>("illust_ids[]", illustId)).ToList();

            await PostAsync("/add", parameters).Stay();
        }
    }
}