using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ユーザー詳細
    /// </summary>
    public class UserDetail
    {
        /// <summary>
        ///     ユーザー情報
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        ///     プロフィール
        /// </summary>
        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        /// <summary>
        ///     プロフィールの公開制限
        /// </summary>
        [JsonProperty("profile_publicity")]
        public ProfilePublicity ProfilePublicity { get; set; }

        /// <summary>
        ///     作業環境
        /// </summary>
        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }
    }
}