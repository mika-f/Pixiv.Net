using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class MetaSinglePage
    {
        [JsonProperty("original_image_url")]
        public string OriginalImageUrl { get; set; }
    }
}