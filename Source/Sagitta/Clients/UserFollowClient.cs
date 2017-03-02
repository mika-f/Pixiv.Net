using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class UserFollowClient : ApiClient
    {
        public UserFollowClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task AddAsync(int userId, Restrict restrict = Restrict.Public)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v1/user/follow/add", parameters);
        }

        public async Task DeleteAsync(int userId)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString())
            };
            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v1/user/follow/delete", parameters);
        }
    }
}