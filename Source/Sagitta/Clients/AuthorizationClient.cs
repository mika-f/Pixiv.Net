using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class AuthorizationClient : ApiClient
    {
        public AuthorizationClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task<OAuthToken> TokenAsync(string username, string password, string deviceToken = "pixiv")
        {
            Ensure.NotNullOrWhitespace(username, nameof(username));
            Ensure.NotNullOrWhitespace(password, nameof(password));
            Ensure.NotNullOrWhitespace(deviceToken, nameof(deviceToken));

            var parameters = new Dictionary<string, string>
            {
                {"client_id", PixivClient.ClientId},
                {"client_secret", PixivClient.ClientSecret},
                {"device_token", deviceToken},
                {"get_secure_url", "true"},
                {"grant_type", "password"},
                {"username", username},
                {"password", password}
            };

            return await PixivClient.PostAsync<OAuthToken>("https://app-api.pixiv.net/auth/token", parameters, false);
        }
    }
}