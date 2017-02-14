using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class BookmarkUsers
    {
        [JsonProperty("users")]
        public IEnumerable<UserWithComment> Users { get; set; }

        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}