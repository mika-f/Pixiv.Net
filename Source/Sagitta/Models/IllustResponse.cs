using Newtonsoft.Json;

namespace Sagitta.Models
{
    internal class IllustResponse
    {
        [JsonProperty("illust")]
        public Illust Illust { get; set; }
    }
}