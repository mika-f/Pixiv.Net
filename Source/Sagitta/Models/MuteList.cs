using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ミュートタグリスト
    /// </summary>
    public class MuteList : ApiResponse
    {
        /// <summary>
        ///     ミュートしているタグリスト
        /// </summary>
        [JsonProperty("muted_tags")]
        public IEnumerable<MutedTag> MutedTags { get; set; }

        /// <summary>
        ///     ミュートしている数
        /// </summary>
        [JsonProperty("muted_count")]
        public int MutedCount { get; set; }

        /// <summary>
        ///     ミュートしているタグの数
        /// </summary>
        [JsonProperty("muted_tags_count")]
        public int MutedTagsCount { get; set; }

        /// <summary>
        ///     ミュートしているユーザーの数
        /// </summary>
        [JsonProperty("muted_users_count")]
        public int MutedUsersCount { get; set; }

        /// <summary>
        ///     最大ミュート数
        /// </summary>
        [JsonProperty("mute_limit_count")]
        public int MuteLimitCount { get; set; }
    }
}