using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class StateRoot
    {
        [JsonProperty("user_state")]
        public UserState UserState { get; set; }
    }
}