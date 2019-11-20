using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Enums;
using Pixiv.Extensions;

namespace Pixiv.Clients.V1.User
{
    public class FollowClient : ApiClient
    {
        internal FollowClient(PixivClient client) : base(client, "/v1/user/follow") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task AddAsync(long userId, Restrict restrict)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };

            await PostAsync("/add", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task DeleteAsync(long userId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId)
            };

            await PostAsync("/delete", parameters).Stay();
        }
    }
}