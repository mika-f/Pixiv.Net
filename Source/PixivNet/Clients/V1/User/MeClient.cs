using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1.User
{
    public class MeClient : ApiClient
    {
        internal MeClient(PixivClient client) : base(client, "/v1/user/me") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<UserState> StateAsync()
        {
            var response = await GetAsync("/state").Stay();
            return response["user_state"]!.ToObject<UserState>()!;
        }
    }
}