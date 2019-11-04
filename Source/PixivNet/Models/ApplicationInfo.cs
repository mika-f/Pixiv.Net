using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class ApplicationInfo : ApiResponse
    {
        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("latest_version")]
        public string LatestVersion { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("notice_exists")]
        public bool IsNoticeExists { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("notice_id")]
        public string NoticeId { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("notice_important")]
        public bool IsNoticeImportant { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("notice_message")]
        public string NoticeMessage { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("store_url")]
        public string StoreUrl { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("update_available")]
        public bool IsUpdateAvailable { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("update_required")]
        public bool IsUpdateRequired { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("update_message")]
        public string UpdateMessage { get; set; }
    }
}