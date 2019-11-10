using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class BookmarkRange : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("bookmark_num_max")]
        public string BookmarkNumMax { get; set; } // integer or "*"

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("bookmark_num_min")]
        public string BookmarkNumMin { get; set; } // integer or "*"

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}