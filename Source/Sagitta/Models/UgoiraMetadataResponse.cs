using Newtonsoft.Json;

namespace Sagitta.Models
{
    internal class UgoiraMetadataResponse
    {
        [JsonProperty("ugoira_metadata")]
        public UgoiraMetadata Metadata { get; set; }
    }
}