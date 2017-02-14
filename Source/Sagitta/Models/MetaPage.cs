using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class MetaPage
    {
        [JsonProperty("image_urls")]
        public ImageUrls ImageUrls { get; set; }
    }
}