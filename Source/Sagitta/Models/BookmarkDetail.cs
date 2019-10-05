using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Enum;

namespace Pixiv.Models
{
    public class BookmarkDetail : ApiResponse
    {
        /// <summary>
        ///     すでにブックマーク済みか
        /// </summary>
        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        /// <summary>
        ///     タグ情報
        /// </summary>
        public IEnumerable<BookmarkDetailTag> Tags { get; set; }

        /// <summary>
        ///     公開制限
        /// </summary>
        [JsonProperty("restrict")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrict Restrict { get; set; }
    }
}