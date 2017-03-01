using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class NovelMarker
    {
        [JsonProperty("page")]
        public int Page { get; set; }
    }
}