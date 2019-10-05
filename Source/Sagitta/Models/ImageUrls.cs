using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     サイズ別画像 URL モデル
    /// </summary>
    public class ImageUrls : ApiResponse
    {
        /// <summary>
        ///     正方形かつ、中くらいなサイズ (370x370) に加工された画像の URL
        /// </summary>
        [JsonProperty("square_medium")]
        public string SquareMedium { get; set; }

        /// <summary>
        ///     中くらいなサイズ (最大 540x540) に加工された画像の URL
        /// </summary>
        [JsonProperty("medium")]
        public string Medium { get; set; }

        /// <summary>
        ///     大きめのサイズ (最大 600x1200) に加工された画像の URL
        /// </summary>
        [JsonProperty("large")]
        public string Large { get; set; }

        /// <summary>
        ///     オリジナルサイズの画像の URL
        ///     **Nullable**
        /// </summary>
        [JsonProperty("original")]
        public string Original { get; set; }
    }
}