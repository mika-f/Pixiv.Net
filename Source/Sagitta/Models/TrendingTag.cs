using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     トレンドタグ
    /// </summary>
    public class TrendingTag : ApiResponse
    {
        /// <summary>
        ///     タグ名
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        ///     イラスト
        /// </summary>
        [JsonProperty("illust")]
        public Illust Illust { get; set; }
    }
}