using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}