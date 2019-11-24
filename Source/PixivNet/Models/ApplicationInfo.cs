using System;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class ApplicationInfo : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

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
        public Uri StoreUrl { get; set; }

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

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}