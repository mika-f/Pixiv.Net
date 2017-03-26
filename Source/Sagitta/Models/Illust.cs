using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Sagitta.Enum;

namespace Sagitta.Models
{
    public class Illust : Post
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IllustType Type { get; set; }

        [JsonProperty("tools")]
        public IEnumerable<string> Tools { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("sanity_level")]
        public int SanityLevel { get; set; }

        [JsonProperty("meta_single_page")]
        public MetaSinglePage MetaSinglePage { get; set; }

        [JsonProperty("meta_pages")]
        public IEnumerable<MetaPage> MetaPages { get; set; }
    }
}