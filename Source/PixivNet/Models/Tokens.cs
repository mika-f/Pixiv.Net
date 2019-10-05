using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     Authorized Information
    /// </summary>
    // MARKED: 7.4.4
    public class Tokens : ApiResponse
    {
        /// <summary>
        ///     Access Token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     Device Token
        /// </summary>
        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }

        /// <summary>
        ///     Expires in (seconds)
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        ///     Refresh Token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        ///     Access Scope
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        ///     OAuth2 token type
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        ///     Authorized User
        /// </summary>
        [JsonProperty("user")]
        public Me User { get; set; }
    }
}