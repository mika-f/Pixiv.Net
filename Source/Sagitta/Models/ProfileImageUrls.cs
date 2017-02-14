using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class ProfileImageUrls
    {
        [JsonProperty("medium")]
        public string Medium { get; set; }
    }
}