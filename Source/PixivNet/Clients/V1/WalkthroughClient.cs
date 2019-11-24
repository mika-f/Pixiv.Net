using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class WalkthroughClient : ApiClient
    {
        internal WalkthroughClient(PixivClient client) : base(client, "/v1/walkthrough") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        public async Task<IllustCollection> IllustsAsync()
        {
            return await GetAsync<IllustCollection>("/illusts").Stay();
        }
    }
}