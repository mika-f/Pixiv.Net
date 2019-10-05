using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     配信チャットにたいする属性
    /// </summary>
    public class MessageFragment : ApiResponse
    {
        /// <summary>
        ///     チャットタイプ
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     本文
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        ///     正規化された本文
        /// </summary>
        [JsonProperty("normalized_body")]
        public string NormalizedBody { get; set; }
    }
}