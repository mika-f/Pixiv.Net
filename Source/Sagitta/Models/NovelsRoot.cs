using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class NovelsRoot
    {
        [JsonProperty("novels")]
        public IEnumerable<Novel> Novels { get; set; }

        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}