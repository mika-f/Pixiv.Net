using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     配信ユーザー
    /// </summary>
    public class LiveUser
    {
        /// <summary>
        ///     ユーザー ID
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     pixiv のユーザー ID
        /// </summary>
        [JsonProperty("pixiv_user_id")]
        public long PixivUserId { get; set; }

        /// <summary>
        ///     ユニーク名
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; set; }

        /// <summary>
        ///     表示名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     アイコン
        /// </summary>
        [JsonProperty("icon")]
        public LiveUserIcon Icon { get; set; }

        /// <summary>
        ///     フォローしているか
        /// </summary>
        [JsonProperty("following")]
        public bool IsFollowing { get; set; }

        /// <summary>
        ///     フォローされているか
        /// </summary>
        [JsonProperty("followed")]
        public bool IsFollowed { get; set; }

        /// <summary>
        ///     ブロックしているか
        /// </summary>
        [JsonProperty("blocking")]
        public bool IsBlocking { get; set; }

        // _links is ignored, FIXME
    }
}