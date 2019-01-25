using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     小説本文の情報
    /// </summary>
    public class NovelText : ApiResponse
    {
        /// <summary>
        ///     マーカー
        /// </summary>
        [JsonProperty("novel_marker")]
        public NovelMarker NovelMarker { get; set; }

        /// <summary>
        ///     本文
        /// </summary>
        [JsonProperty("novel_text")]
        public string Text { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("series_prev")]
        public Series PrevSeries { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("series_next")]
        public Series NextSeries { get; set; }
    }
}