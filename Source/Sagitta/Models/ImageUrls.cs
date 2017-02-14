using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class ImageUrls
    {
        [JsonProperty("square_medium")]
        public string SquareMedium { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }
    }
}