using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     イラストシリーズ
    /// </summary>
    public class IllustSeries : ApiResponse
    {
        /// <summary>
        ///     シリーズ詳細
        /// </summary>
        [JsonProperty("illust_series_detail")]
        public Series IllustSeriesDetail { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("illust_series_context")]
        public IllustSeriesContext IllustSeriesContext { get; set; }
    }
}