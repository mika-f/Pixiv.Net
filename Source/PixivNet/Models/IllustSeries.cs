using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class IllustSeries : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("illust_series_context")]
        public IllustSeriesContext SeriesContext { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("illust_series_detail")]
        public IllustSeriesDetail SeriesDetail { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}