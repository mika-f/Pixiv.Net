using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ページ毎の画像 URL モデル
    /// </summary>
    public class MetaSinglePage : ApiResponse
    {
        /// <summary>
        ///     オリジナルサイズ画像 URL
        /// </summary>
        [JsonProperty("original_image_url")]
        public string OriginalImageUrl { get; set; }
    }
}