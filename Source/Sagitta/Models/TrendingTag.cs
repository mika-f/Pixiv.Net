using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class TrendingTag
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("illust")]
        public Illust Illust { get; set; }
    }
}