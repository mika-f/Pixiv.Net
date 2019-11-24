using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Attributes;
using Pixiv.Enums;

namespace Pixiv.Models
{
    public class BookmarkDetail : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("restrict")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrict Restrict { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("tags")]
        public IEnumerable<BookmarkDetailTag> Tags { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}