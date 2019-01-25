using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ミュートしていたタグ
    /// </summary>
    public class MutedTag : ApiResponse
    {
        /// <summary>
        ///     タグ
        /// </summary>
        [JsonProperty("tag")]
        public Tag Tag { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("is_premium_slot")]
        public bool IsPremiumSlot { get; set; }
    }
}