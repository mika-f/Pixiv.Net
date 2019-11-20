using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class TrendTag : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [ApiVersion("7.7.7")]
        [MarkedAs("7.7.7")]
        [JsonProperty("translated_name")]
        public string? TranslatedName { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("illust")]
        public Illust Illust { get; set; }

#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}