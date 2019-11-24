using System;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class ImageUrls : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("large")]
        public Uri Large { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("medium")]
        public Uri Medium { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("square_medium")]
        public Uri SquareMedium { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("original")]
        public Uri? Original { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}