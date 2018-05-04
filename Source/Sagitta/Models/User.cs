using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ユーザー
    /// </summary>
    public class User
    {
        /// <summary>
        ///     ユーザー ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     ユーザー名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     アカウント名
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("profile_image_urls")]
        public ProfileImageUrls ProfileImageUrls { get; set; }

        /// <summary>
        ///     フォローしているか否か
        /// </summary>
        [JsonProperty("is_followed")]
        public bool IsFollowed { get; set; }

        /// <summary>
        ///     メールアドレス (※認証ユーザーのもののみ取得可能)
        /// </summary>
        [JsonProperty("mail_address")]
        public string MailAddress { get; set; }

        /// <summary>
        ///     プレミアムユーザーか否か
        /// </summary>
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        /// <summary>
        ///     制限レベル
        /// </summary>
        [JsonProperty("x_restrict")]
        public int RestrictLevel { get; set; }

        /// <summary>
        ///     メール認証済みかどうか (※認証ユーザーのもののみ取得可能)
        /// </summary>
        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }
    }
}