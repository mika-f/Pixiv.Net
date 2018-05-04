using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     認証情報
    /// </summary>
    public class Tokens
    {
        /// <summary>
        ///     アクセストークン
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     有効期間 (秒)
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        ///     認証形式
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        ///     スコープ
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        ///     リフレッシュトークン
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        ///     認証ユーザー情報
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        ///     デバイストークン
        /// </summary>
        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }
    }
}