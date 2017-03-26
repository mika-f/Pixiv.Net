using Newtonsoft.Json;

namespace Sagitta.Models
{
    internal class ApplicationInfoResponse
    {
        [JsonProperty("application_info")]
        public ApplicationInfo ApplicationInfo { get; set; }
    }
}