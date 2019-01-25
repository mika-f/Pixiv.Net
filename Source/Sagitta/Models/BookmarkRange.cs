using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     TODO
    /// </summary>
    public class BookmarkRange : ApiResponse
    {
        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("bookmark_num_min")]
        public string BookmarkNumMin { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("bookmark_num_max")]
        public string BookmarkNumMax { get; set; }
    }
}