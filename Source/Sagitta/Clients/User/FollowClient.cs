using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;

namespace Sagitta.Clients.User
{
    /// <summary>
    ///     フォロー関連 API
    /// </summary>
    public class FollowClient : ApiClient
    {
        /// <inheritdoc />
        internal FollowClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     指定したユーザーをフォローします。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        /// <param name="restrict">公開制限</param>
        public async Task AddAsync(long userId, Restrict restrict = Restrict.Public)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameter())
            };

            await PixivClient.PostAsync("https://app-api.pixiv.net/v1/user/follow/add", parameters).Stay();
        }

        /// <summary>
        ///     指定したユーザーのフォローを解除します。
        /// </summary>
        /// <param name="userId">ユーザー ID</param>
        public async Task DeleteAsync(long userId)
        {
            Ensure.GreaterThanZero(userId, nameof(userId));

            var parameters = new List<KeyValuePair<string, string>> {new KeyValuePair<string, string>("user_id", userId.ToString())};

            await PixivClient.PostAsync("https://app-api.pixiv.net/v1/user/follow/delete", parameters).Stay();
        }
    }
}