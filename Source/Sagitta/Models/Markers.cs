using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Markers
    {
        [JsonProperty("marked_novels")]
        public IEnumerable<Marker> MarkedNovels { get; set; }

        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}