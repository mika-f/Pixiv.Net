using System;
using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Models;

namespace Sagitta.Clients.User
{
    /// <summary>
    ///     ユーザープロフィール関連 API
    /// </summary>
    public class ProfileClient : ApiClient
    {
        /// <inheritdoc />
        internal ProfileClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     プロフィールのプリセット情報を取得します。
        /// </summary>
        /// <returns>
        ///     <see cref="ProfilePresets" />
        /// </returns>
        public async Task<ProfilePresets> PresetsAsync()
        {
            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/user/profile/presets", PixivClient.EmptyParameter).Stay();
            return response["profile_presets"].ToObject<ProfilePresets>();
        }

        /// <summary>
        ///     プロフィール情報を更新します。
        ///     未実装です。
        /// </summary>
        public void Edit()
        {
            throw new NotImplementedException();
        }
    }
}