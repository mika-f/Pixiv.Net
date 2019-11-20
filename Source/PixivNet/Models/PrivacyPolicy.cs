using System;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class PrivacyPolicy : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("message")]
        public string Message { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("version")]
        public string Version { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}