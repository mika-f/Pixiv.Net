using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class MuteClient : ApiClient
    {
        internal MuteClient(PixivClient client) : base(client, "/v1/mute") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<MuteList> ListAsync()
        {
            return await GetAsync<MuteList>("/list").Stay();
        }
    }
}