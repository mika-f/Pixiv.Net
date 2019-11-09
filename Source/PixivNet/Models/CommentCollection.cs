using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class CommentCollection : ApiResponse
    {
        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("comments")]
        public IEnumerable<Comment> Comments { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("next_url")]
        public Uri? NextUrl { get; set; }
    }
}