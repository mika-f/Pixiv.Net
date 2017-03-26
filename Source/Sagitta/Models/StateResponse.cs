using Newtonsoft.Json;

namespace Sagitta.Models
{
    internal class StateResponse
    {
        [JsonProperty("user_state")]
        public UserState UserState { get; set; }
    }
}