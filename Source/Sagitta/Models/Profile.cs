using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Sagitta.Converters;
using Sagitta.Enum;

namespace Sagitta.Models
{
    /// <summary>
    ///     プロフィール
    /// </summary>
    public class Profile
    {
        /// <summary>
        ///     住所 ID
        /// </summary>
        [JsonProperty("address_id")]
        public int? AddressId { get; set; }

        /// <summary>
        ///     背景画像 URL
        /// </summary>
        [JsonProperty("background_image_url")]
        public string BackgroundImageUrl { get; set; }

        /// <summary>
        ///     誕生日
        /// </summary>
        [JsonProperty("birth")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Birth { get; set; }

        /// <summary>
        ///     誕生日 (日時)
        /// </summary>
        [JsonProperty("birth_day")]
        public string BirthDay { get; set; }

        /// <summary>
        ///     誕生日 (年)
        /// </summary>
        [JsonProperty("birth_year")]
        public int? BirthYear { get; set; }

        /// <summary>
        ///     国コード
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        ///     性別
        /// </summary>
        [JsonProperty("gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender? Gender { get; set; }

        /// <summary>
        ///     職業
        /// </summary>
        [JsonProperty("job")]
        public string Job { get; set; }

        /// <summary>
        ///     職業 ID
        /// </summary>
        [JsonProperty("job_id")]
        public int? JobId { get; set; }

        /// <summary>
        ///     地域
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        ///     フォロー数
        /// </summary>
        [JsonProperty("total_follow_users")]
        public int TotalFollowUsers { get; set; }

        /// <summary>
        ///     フォロワー数
        /// </summary>
        [JsonProperty("total_follower")]
        public int TotalFollower { get; set; }

        /// <summary>
        ///     マイピク数
        /// </summary>
        [JsonProperty("total_mypixiv_users")]
        public int TotalMypixivUsers { get; set; }

        /// <summary>
        ///     イラスト投稿数
        /// </summary>
        [JsonProperty("total_illusts")]
        public int TotalIllusts { get; set; }

        /// <summary>
        ///     マンガ投稿数
        /// </summary>
        [JsonProperty("total_manga")]
        public int TotalManga { get; set; }

        /// <summary>
        ///     小説投稿数
        /// </summary>
        [JsonProperty("total_novels")]
        public int TotalNovels { get; set; }

        /// <summary>
        ///     イラストブックマーク数 (公開のみ)
        /// </summary>
        [JsonProperty("total_illust_bookmarks_public")]
        public int TotalIllustBookmarksPublic { get; set; }

        /// <summary>
        ///     イラストシリーズ投稿数
        /// </summary>
        [JsonProperty("total_illust_series")]
        public int TotalIllustSeries { get; set; }

        /// <summary>
        ///     Twitter アカウント
        /// </summary>
        [JsonProperty("twitter_account")]
        public string TwitterAccount { get; set; }

        /// <summary>
        ///     Twitter URL
        /// </summary>
        [JsonProperty("twitter_url")]
        public string TwitterUrl { get; set; }

        /// <summary>
        ///     Pawoo URL
        /// </summary>
        [JsonProperty("pawoo_url")]
        public string PawooUrl { get; set; }

        /// <summary>
        ///     ホームページ
        /// </summary>
        [JsonProperty("webpage")]
        public string Webpage { get; set; }

        /// <summary>
        ///     プレミアムユーザーか
        /// </summary>
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        /// <summary>
        ///     プロフィール画像をプリセット以外の物を使用しているか
        /// </summary>
        [JsonProperty("is_using_custom_profile_image")]
        public bool IsUsingCustomProfileImage { get; set; }
    }
}