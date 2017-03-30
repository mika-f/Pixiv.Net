using Newtonsoft.Json;

namespace Sagitta.Models
{
    internal class NovelResponse
    {
        [JsonProperty("novel")]
        public Novel Novel { get; set; }
    }
}