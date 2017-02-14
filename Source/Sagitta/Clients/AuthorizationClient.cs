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

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", PixivClient.ClientId),
                new KeyValuePair<string, string>("client_secret", PixivClient.ClientSecret),
                new KeyValuePair<string, string>("device_token", deviceToken),
                new KeyValuePair<string, string>("get_secure_url", "true"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };

            var response = await PixivClient.PostAsync<OAuthResponse>("https://oauth.secure.pixiv.net/auth/token", parameters, false);
            if (response != null)
                PixivClient.AccessToken = response.Response.AccessToken;
            return response?.Response;
        }
    }
}