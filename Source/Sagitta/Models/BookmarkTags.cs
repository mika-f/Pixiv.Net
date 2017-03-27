using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class BookmarkTags : Cursorable<BookmarkTags>
    {
        [JsonProperty("bookmark_tags")]
        public IList<BookmarkTag> Tags { get; set; }
    }
}