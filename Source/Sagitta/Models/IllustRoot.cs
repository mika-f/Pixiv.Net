using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class IllustRoot
    {
        [JsonProperty("illust")]
        public Illust Illust { get; set; }
    }
}