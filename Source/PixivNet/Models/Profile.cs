using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class Profile : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("background_image_url")]
        public Uri BackgroundImageUrl { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("birth")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? Birth { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("birth_day")]
        public string BirthDay { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("birth_year")]
        public long BirthYear { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_using_custom_profile_image")]
        public bool IsUsingCustomProfileImage { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("job")]
        public string Job { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("job_id")]
        public long JobId { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("pawoo_url")]
        public Uri? PawooUrl { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("region")]
        public string Region { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_follow_users")]
        public long TotalFollowUsers { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_illusts")]
        public long TotalIllusts { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_illust_bookmarks_public")]
        public long TotalIllustBookmarksPublic { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_illust_series")]
        public long TotalIllustSeries { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_manga")]
        public long TotalManga { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_novels")]
        public long TotalNovels { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_novel_series")]
        public long TotalNovelSeries { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_mypixiv_users")]
        public long TotalMypixivUsers { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("twitter_account")]
        public string? TwitterAccount { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("twitter_url")]
        public Uri? TwitterUrl { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("webpage")]
        public string? Webpage { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}