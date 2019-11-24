using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class UserDetail : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("profile_publicity")]
        public ProfilePublicity ProfilePublicity { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("user")]
        public User User { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}