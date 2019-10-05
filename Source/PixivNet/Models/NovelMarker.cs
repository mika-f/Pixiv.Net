using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     小説マーカー
    /// </summary>
    public class NovelMarker : ApiResponse
    {
        /// <summary>
        ///     マーカーを付けたページ
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }
    }
}