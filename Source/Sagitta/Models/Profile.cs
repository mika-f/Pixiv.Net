using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Sagitta.Enum;

namespace Sagitta.Models
{
    public class Profile
    {
        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender? Gender { get; set; }

        [JsonProperty("birth")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? Birth { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("total_follow_users")]
        public int TotalFollowUsers { get; set; }

        [JsonProperty("total_follower")]
        public int TotalFollower { get; set; }

        [JsonProperty("total_mypixi_users")]
        public int TotalMypixivUsers { get; set; }

        [JsonProperty("total_illusts")]
        public int TotalIllusts { get; set; }

        [JsonProperty("total_manga")]
        public int TotalManga { get; set; }

        [JsonProperty("total_novels")]
        public int TotalNovels { get; set; }

        [JsonProperty("total_illust_bookmarks_public")]
        public int TotalIllustBookmarksPublic { get; set; }

        [JsonProperty("background_image_url")]
        public string BackgroundImageUrl { get; set; }

        [JsonProperty("twitter_account")]
        public string TwitterAccount { get; set; }

        [JsonProperty("twitter_url")]
        public string TwitterUrl { get; set; }

        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }
    }
}