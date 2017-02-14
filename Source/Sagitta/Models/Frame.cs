using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Frame
    {
        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("delay")]
        public int Delay { get; set; }
    }
}