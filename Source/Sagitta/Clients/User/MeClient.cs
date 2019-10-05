using System.Threading.Tasks;

using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.User
{
    /// <summary>
    ///     認証ユーザー関連 API
    /// </summary>
    public class MeClient : ApiClient
    {
        /// <inheritdoc />
        internal MeClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     認証ユーザーの現在の状態を取得します。
        /// </summary>
        /// <returns>
        ///     <see cref="UserState" />
        /// </returns>
        public async Task<UserState> StateAsync()
        {
            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/user/me/state").Stay();
            return response["user_state"].ToObject<UserState>();
        }
    }
}