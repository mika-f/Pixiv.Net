using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    /// <summary>
    ///     認証関連 API
    /// </summary>
    // MARKED: 7.4.4
    public class AuthenticationClient : ApiClient
    {
        /// <inheritdoc />
        internal AuthenticationClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     ユーザーネーム (メールアドレス) およびパスワードを使用して、アクセストークンを取得します。
        ///     ログインアラートを発生させたくない場合は、前回取得した <see cref="Tokens" /> から、 <see cref="Tokens.DeviceToken" /> を指定する必要があります。
        /// </summary>
        /// <param name="username">ユーザーネームもしくはメールアドレス</param>
        /// <param name="password">パスワード</param>
        /// <param name="deviceToken">デバイス固有トークン</param>
        /// <returns>ログイン情報</returns>
        public async Task<Tokens> LoginAsync(string username, string password, string deviceToken = "pixiv")
        {
            Ensure.NotNullOrWhitespace(username, nameof(username));
            Ensure.NotNullOrWhitespace(password, nameof(password));

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("username", username),
                new KeyValuePair<string, object>("password", password),
                new KeyValuePair<string, object>("client_id", PixivClient.ClientId),
                new KeyValuePair<string, object>("client_secret", PixivClient.ClientSecret),
                new KeyValuePair<string, object>("get_secure_url", true),
                new KeyValuePair<string, object>("device_token", deviceToken),
                new KeyValuePair<string, object>("grant_type", "password"),
                new KeyValuePair<string, object>("include_policy", true)
            };
            var response = await PixivClient.PostAsync("https://oauth.secure.pixiv.net/auth/token", parameters).Stay();
            var tokens = response["response"].ToObject<Tokens>();
            PixivClient.AccessToken = tokens.AccessToken;
            PixivClient.RefreshToken = tokens.RefreshToken;

            return tokens;
        }

        /// <summary>
        ///     リフレッシュトークンを使用して、アクセストークンを更新します。
        ///     ログインアラートを発生させたくない場合は、前回取得した <see cref="Tokens" /> から、 <see cref="Tokens.DeviceToken" /> を指定する必要があります。
        /// </summary>
        /// <param name="refreshToken">
        ///     <see cref="Tokens.RefreshToken" />
        /// </param>
        /// <param name="deviceToken">デバイス固有トークン</param>
        /// <returns>更新されたログイン情報</returns>
        public async Task<Tokens> RefreshAsync(string refreshToken, string deviceToken = "pixiv")
        {
            Ensure.NotNullOrWhitespace(refreshToken, nameof(refreshToken));

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("refresh_token", refreshToken),
                new KeyValuePair<string, object>("client_id", PixivClient.ClientId),
                new KeyValuePair<string, object>("client_secret", PixivClient.ClientSecret),
                new KeyValuePair<string, object>("get_secure_url", true),
                new KeyValuePair<string, object>("device_token", deviceToken),
                new KeyValuePair<string, object>("grant_type", "refresh_token"),
                new KeyValuePair<string, object>("include_policy", true)
            };
            var response = await PixivClient.PostAsync("https://oauth.secure.pixiv.net/auth/token", parameters).Stay();
            var tokens = response["response"].ToObject<Tokens>();
            PixivClient.AccessToken = tokens.AccessToken;
            PixivClient.RefreshToken = tokens.RefreshToken;

            return tokens;
        }
    }
}