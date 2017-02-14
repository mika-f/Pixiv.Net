using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Series
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}