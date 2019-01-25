using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UserPreview : ApiResponse
    {
        /// <summary>
        ///     ユーザー情報
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        ///     イラスト (最大つ枚)
        /// </summary>
        [JsonProperty("illusts")]
        public IEnumerable<Illust> Illusts { get; set; }

        /// <summary>
        ///     小説 (最大3つ)
        /// </summary>
        public IEnumerable<Novel> Novels { get; set; }

        /// <summary>
        ///     ミュートしているか
        /// </summary>
        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }
    }
}