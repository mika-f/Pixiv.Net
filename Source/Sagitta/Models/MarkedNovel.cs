using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     マーキングした小説
    /// </summary>
    public class MarkedNovel : ApiResponse
    {
        /// <summary>
        ///     小説
        /// </summary>
        [JsonProperty("novel")]
        public Novel Novel { get; set; }

        /// <summary>
        ///     マーカー
        /// </summary>
        [JsonProperty("novel_marker")]
        public NovelMarker Marker { get; set; }
    }
}