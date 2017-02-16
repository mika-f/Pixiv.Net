using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UserMini
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_image_urls")]
        public ProfileImageUrls ProfileImageUrls { get; set; }
    }
}