using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     TODO
    /// </summary>
    public class IllustSeriesContext
    {
        /// <summary>
        ///     並び順
        /// </summary>
        [JsonProperty("content_order")]
        public int ContentOrder { get; set; }

        /// <summary>
        ///     前の投稿
        /// </summary>
        [JsonProperty("prev")]
        public Illust Prev { get; set; }

        /// <summary>
        ///     次の投稿
        /// </summary>
        [JsonProperty("next")]
        public Illust Next { get; set; }
    }
}