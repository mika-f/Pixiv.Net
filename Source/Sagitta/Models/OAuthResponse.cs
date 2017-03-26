using Newtonsoft.Json;

namespace Sagitta.Models
{
    internal class OAuthResponse
    {
        [JsonProperty("response")]
        public OAuthToken Response { get; set; }
    }
}