using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Sagitta.Enum;

namespace Sagitta.Models
{
    public class BookmarkDetail
    {
        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<BookmarkTag> Tags { get; set; }

        [JsonProperty("restrict")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrict Restrict { get; set; }
    }
}