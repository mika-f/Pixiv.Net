using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class BookmarkTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_registered")]
        public bool IsRegistered { get; set; }
    }
}