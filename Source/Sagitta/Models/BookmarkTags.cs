using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class BookmarkTags
    {
        [JsonProperty("bookmark_tags")]
        public IList<BookmarkTag> Tags { get; set; }

        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}