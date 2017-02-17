using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class MuteTag
    {
        [JsonProperty("tag")]
        public Tag Tag { get; set; }

        [JsonProperty("is_premium_slot")]
        public bool IsPremiumSlot { get; set; }
    }
}