using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Autocomplete
    {
        [JsonProperty("search_auto_complete_keywords")]
        public IEnumerable<string> Keywords { get; set; }
    }
}