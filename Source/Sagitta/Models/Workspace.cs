using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     作業環境
    /// </summary>
    public class Workspace : ApiResponse
    {
        /// <summary>
        ///     コンピュータ
        /// </summary>
        [JsonProperty("pc")]
        public string Pc { get; set; }

        /// <summary>
        ///     モニター
        /// </summary>
        [JsonProperty("monitor")]
        public string Monitor { get; set; }

        /// <summary>
        ///     ソフト
        /// </summary>
        [JsonProperty("tool")]
        public string Tool { get; set; }

        /// <summary>
        ///     スキャナー
        /// </summary>
        [JsonProperty("scanner")]
        public string Scanner { get; set; }

        /// <summary>
        ///     タブレット
        /// </summary>
        [JsonProperty("tablet")]
        public string Tablet { get; set; }

        /// <summary>
        ///     マウス
        /// </summary>
        [JsonProperty("mouse")]
        public string Mouse { get; set; }

        /// <summary>
        ///     プリンター
        /// </summary>
        [JsonProperty("printer")]
        public string Printer { get; set; }

        /// <summary>
        ///     机の上にあるもの
        /// </summary>
        [JsonProperty("desktop")]
        public string Desktop { get; set; }

        /// <summary>
        ///     絵を描く時に聞く音楽
        /// </summary>
        [JsonProperty("music")]
        public string Music { get; set; }

        /// <summary>
        ///     机
        /// </summary>
        [JsonProperty("desk")]
        public string Desk { get; set; }

        /// <summary>
        ///     椅子
        /// </summary>
        [JsonProperty("chair")]
        public string Chair { get; set; }

        /// <summary>
        ///     その他
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        ///     作業環境画像 URL
        /// </summary>
        [JsonProperty("workspace_image_url")]
        public string WorkspaceImageUrl { get; set; }
    }
}