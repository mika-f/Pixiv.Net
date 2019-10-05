using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ブックマーク詳細に関するタグ情報
    /// </summary>
    public class BookmarkDetailTag : ApiResponse
    {
        /// <summary>
        ///     タグ名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     ブックマークにタグ登録済みか
        /// </summary>
        [JsonProperty("is_registered")]
        public bool IsRegistered { get; set; }
    }
}