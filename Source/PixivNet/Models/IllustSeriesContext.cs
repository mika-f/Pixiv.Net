using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class IllustSeriesContext : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("content_order")]
        public long ContentOrder { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("next")]
        public Illust? Next { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("prev")]
        public Illust? Previous { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}