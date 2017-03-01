using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Text
    {
        [JsonProperty("novel_marker")]
        public NovelMarker NovelMarker { get; set; }

        [JsonProperty("novel_text")]
        public string Body { get; set; }

        [JsonProperty("series_prev")]
        public Series PrevSeries { get; set; }

        [JsonProperty("series_next")]
        public Series NextSeries { get; set; }
    }
}