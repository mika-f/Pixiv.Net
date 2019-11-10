using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class IllustSeriesDetail : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("cover_image_urls")]
        public CoverImageUrls CoverImageUrls { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("create_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreateDate { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("height")]
        public long Height { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("series_work_count")]
        public long SeriesWorkCount { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("title")]
        public string Title { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("user")]
        public MinifiedUser User { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("width")]
        public long Width { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}