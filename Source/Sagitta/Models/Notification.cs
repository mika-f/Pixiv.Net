using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Notification
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }
    }
}