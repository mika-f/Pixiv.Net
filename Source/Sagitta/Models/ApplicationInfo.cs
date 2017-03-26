using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class ApplicationInfo
    {
        [JsonProperty("latest_version")]
        public string LatestVersion { get; set; }

        [JsonProperty("update_required")]
        public bool IsUpdateRequired { get; set; }

        [JsonProperty("update_available")]
        public bool IsUpdateAvailable { get; set; }

        [JsonProperty("update_message")]
        public string UpdateMessage { get; set; }

        [JsonProperty("notice_exists")]
        public bool NoticeExists { get; set; }

        [JsonProperty("store_url")]
        public string StoreUrl { get; set; }

        [JsonProperty("notice_id")]
        public string NoticeId { get; set; }

        [JsonProperty("notice_important")]
        public bool IsNoticeImportant { get; set; }

        [JsonProperty("notice_message")]
        public string NoticeMessage { get; set; }
    }
}