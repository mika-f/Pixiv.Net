using System;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class ProfileImageUrls : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("medium")]
        public Uri Medium { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("px_16x16")]
        public Uri? X16 { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("px_50x50")]
        public Uri? X50 { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("px_170x170")]
        public Uri? X170 { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}