using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     国
    /// </summary>
    public class Country : ApiResponse
    {
        /// <summary>
        ///     国コード
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     国名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}