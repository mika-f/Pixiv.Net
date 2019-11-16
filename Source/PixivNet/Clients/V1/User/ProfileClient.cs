using System;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1.User
{
    public class ProfileClient : ApiClient
    {
        internal ProfileClient(PixivClient client) : base(client, "/v1/user/profile") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<ProfilePresets> PresetsAsync()
        {
            var response = await GetAsync("/presets").Stay();
            return response["profile_presets"].ToObject<ProfilePresets>();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public Task EditAsync()
        {
            throw new NotImplementedException();
        }
    }
}