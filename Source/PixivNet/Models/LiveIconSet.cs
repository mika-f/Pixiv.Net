using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     アイコンセット
    /// </summary>
    public class LiveIconSet : ApiResponse
    {
        // これらは本当に使われているのか教えて欲しい

        /// <summary>
        ///     オリジナルサイズ
        /// </summary>
        [JsonProperty("original")]
        public LiveIcon Original { get; set; }

        /// <summary>
        ///     180x180 にリサイズされた画像
        /// </summary>
        [JsonProperty("sq180")]
        public LiveIcon Square180 { get; set; }

        /// <summary>
        ///     (180x180 webp) FIXME
        /// </summary>
        [JsonProperty("pxsq180")]
        public LiveIcon PxSquare180 { get; set; }

        /// <summary>
        ///     (540x540) FIXME
        /// </summary>
        [JsonProperty("w540")]
        public LiveIcon W540 { get; set; }

        /// <summary>
        ///     (540x540 webp) FIXME
        /// </summary>
        [JsonProperty("pxw540")]
        public LiveIcon Pxw540 { get; set; }

        /// <summary>
        ///     60x60 にリサイズされた画像
        /// </summary>
        [JsonProperty("sq60")]
        public LiveIcon Square60 { get; set; }

        /// <summary>
        ///     (60x60 webp) FIXME
        /// </summary>
        [JsonProperty("pxsq60")]
        public LiveIcon PxSquare60 { get; set; }

        /// <summary>
        ///     120x120 にリサイズされた画像
        /// </summary>
        [JsonProperty("sq120")]
        public LiveIcon Square120 { get; set; }

        /// <summary>
        ///     (120x120 webp) FIXME
        /// </summary>
        [JsonProperty("pxsq120")]
        public LiveIcon PxSquare120 { get; set; }

        /// <summary>
        ///     (240x240) FIXME
        /// </summary>
        [JsonProperty("w240")]
        public LiveIcon W240 { get; set; }

        /// <summary>
        ///     (240x240 webp) FIXME
        /// </summary>
        [JsonProperty("pxw240")]
        public LiveIcon Pxw240 { get; set; }
    }
}