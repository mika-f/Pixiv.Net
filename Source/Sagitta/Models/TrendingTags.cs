using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class TrendingTags
    {
        [JsonProperty("trend_tags")]
        public IList<TrendingTag> Tags { get; set; }
    }
}