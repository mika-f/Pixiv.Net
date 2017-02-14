using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UserWithComment : User
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}