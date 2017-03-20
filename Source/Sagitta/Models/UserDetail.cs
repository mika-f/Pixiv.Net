using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UserDetail
    {
        [JsonProperty("user")]
        public UserWithComment User { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("profile_publicity")]
        public ProfilePublicity ProfilePublicity { get; set; }

        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }
    }
}