using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     ブックマークタグ
    /// </summary>
    public class BookmarkTag : ApiResponse
    {
        /// <summary>
        ///     タグ名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     タグ使用数
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}