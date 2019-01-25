using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     配信ユーザーのアイコン
    /// </summary>
    public class LiveIcon : ApiResponse
    {
        /// <summary>
        ///     幅
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        ///     高さ
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        ///     URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        ///     URL@2x
        /// </summary>
        [JsonProperty("url2x")]
        public string Url2X { get; set; }
    }
}