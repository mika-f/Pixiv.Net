using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     住所
    /// </summary>
    public class Address : ApiResponse
    {
        /// <summary>
        ///     ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     名前
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("is_global")]
        public bool IsGlobal { get; set; }
    }
}