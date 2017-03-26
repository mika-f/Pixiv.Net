using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UgoiraMetadata
    {
        [JsonProperty("zip_urls")]
        public ZipUrls ZipUrls { get; set; }

        [JsonProperty("frames")]
        public IEnumerable<Frame> Frames { get; set; }
    }
}