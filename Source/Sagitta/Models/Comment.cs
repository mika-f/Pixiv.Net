using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sagitta.Models
{
    public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("comment")]
        public string Body { get; set; }

        [JsonProperty("date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("user")]
        public UserBase User { get; set; }

        [JsonProperty("parent_comment")]
        public Comment ParentComment { get; set; }
    }
}