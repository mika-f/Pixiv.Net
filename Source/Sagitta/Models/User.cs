using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class User : UserMini
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("is_followed")]
        public bool IsFollowed { get; set; }
    }
}