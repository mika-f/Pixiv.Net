using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Enum;
using Pixiv.Extensions;
using Pixiv.Helpers;

namespace Pixiv.Clients.User
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

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>("restrict", restrict.ToParameter())
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

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("user_id", userId) };

            await PixivClient.PostAsync("https://app-api.pixiv.net/v1/user/follow/delete", parameters).Stay();
        }
    }
}