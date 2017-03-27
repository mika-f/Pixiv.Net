using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class CommentCollection : Cursorable<CommentCollection>
    {
        [JsonProperty("total_comments")]
        public int TotalComments { get; set; }

        [JsonProperty("comments")]
        public IEnumerable<Comment> Comments { get; set; }
    }
}