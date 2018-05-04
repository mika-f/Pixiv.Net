using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     pixiv sketch 配信詳細
    /// </summary>
    public class LiveResponse<T>
    {
        /// <summary>
        ///     <see cref="T" />
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        ///     エラー情報 FIXME
        /// </summary>
        [JsonProperty("errors")]
        public object Errors { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("_links")]
        public object Links { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("rand")]
        public string Rand { get; set; }
    }
}