using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class BookmarkUsers : Cursorable<BookmarkUsers>
    {
        [JsonProperty("users")]
        public IEnumerable<UserWithComment> Users { get; set; }
    }
}