using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     TODO
    /// </summary>
    public class LiveUserIcon
    {
        /// <summary>
        ///     アイコン ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     アイコンタイプ
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        // color is ignored, FIXME

        /// <summary>
        ///     アイコン URL セット
        /// </summary>
        [JsonProperty("photo")]
        public LiveIconSet IconSet { get; set; }
    }
}