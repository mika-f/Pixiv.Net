using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UgoiraMetadataResponse
    {
        [JsonProperty("ugoira_metadata")]
        public UgoiraMetadata Metadata { get; set; }
    }

    public class UgoiraMetadata
    {
        [JsonProperty("zip_urls")]
        public ZipUrls ZipUrls { get; set; }

        [JsonProperty("frames")]
        public IEnumerable<Frame> Frames { get; set; }
    }
}