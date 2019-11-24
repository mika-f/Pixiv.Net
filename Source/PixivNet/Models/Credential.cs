using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class Credential : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("user")]
        public Myself User { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}