using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Novel : Post
    {
        [JsonProperty("text_length")]
        public int TextLength { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }
    }
}