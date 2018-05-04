using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     小説マーカー
    /// </summary>
    public class NovelMarker
    {
        /// <summary>
        ///     マーカーを付けたページ
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }
    }
}