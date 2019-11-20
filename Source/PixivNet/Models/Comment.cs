using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class Comment : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("comment")]
        public string Text { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Date { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("has_replies")]
        public bool HasReplies { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("user")]
        public MinifiedUser User { get; set; } // Should I create a new class that dropped is_followed property from MinifiedUser?

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}