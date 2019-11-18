using System.Collections.Generic;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class MuteList : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("muted_tags")]
        public IEnumerable<ApiResponse> MutedTags { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("muted_users")]
        public IEnumerable<ApiResponse> MutedUsers { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("mute_limit_count")]
        public long MuteLimitCount { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("muted_count")]
        public long MutedCount { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("muted_tags_count")]
        public long MutedTagsCount { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("muted_users_count")]
        public long MutedUsersCount { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}