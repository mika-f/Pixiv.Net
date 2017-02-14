using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("profile_image_urls")]
        public ProfileImageUrls ProfileImageUrls { get; set; }

        [JsonProperty("is_followed")]
        public bool IsFollowed { get; set; }
    }
}