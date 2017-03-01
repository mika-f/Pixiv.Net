using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Marker
    {
        [JsonProperty("novel")]
        public Novel Novel { get; set; }

        [JsonProperty("novel_marker")]
        public NovelMarker NovelMarker { get; set; }
    }
}