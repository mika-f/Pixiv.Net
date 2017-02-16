using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class CommentsRoot
    {
        [JsonProperty("total_comments")]
        public int TotalComments { get; set; }

        [JsonProperty("comments")]
        public IEnumerable<Comment> Comments { get; set; }

        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}