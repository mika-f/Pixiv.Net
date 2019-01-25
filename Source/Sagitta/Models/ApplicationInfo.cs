using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     アプリケーション情報
    /// </summary>
    public class ApplicationInfo : ApiResponse
    {
        /// <summary>
        ///     リリースされている最新バージョンの番号
        /// </summary>
        [JsonProperty("latest_version")]
        public string LatestVersion { get; set; }

        /// <summary>
        ///     現在使用しているクライアントに対してアップデートが必要か否か
        /// </summary>
        [JsonProperty("update_required")]
        public bool IsUpdateRequired { get; set; }

        /// <summary>
        ///     アップデートが利用可能か
        /// </summary>
        [JsonProperty("update_available")]
        public bool IsUpdateAvailable { get; set; }

        /// <summary>
        ///     更新用メッセージ
        /// </summary>
        [JsonProperty("update_message")]
        public string UpdateMessage { get; set; }

        /// <summary>
        ///     通知があるか否か
        /// </summary>
        [JsonProperty("notice_exists")]
        public bool IsNoticeExists { get; set; }

        /// <summary>
        ///     ストア URL
        /// </summary>
        [JsonProperty("store_url")]
        public string StoreUrl { get; set; }

        /// <summary>
        ///     通知 ID
        /// </summary>
        [JsonProperty("notice_id")]
        public string NoticeId { get; set; }

        /// <summary>
        ///     通知が重要かどうか
        /// </summary>
        [JsonProperty("notice_important")]
        public bool IsNoticeImportant { get; set; }

        /// <summary>
        ///     通知メッセージ
        /// </summary>
        [JsonProperty("notice_message")]
        public string NoticeMessage { get; set; }
    }
}