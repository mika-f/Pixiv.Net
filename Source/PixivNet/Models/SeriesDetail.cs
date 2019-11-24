using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class SeriesDetail : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("illust_series_detail")]
        public IllustSeriesDetail IllustSeriesDetail { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("illust_series_first_illust")]
        public Illust IllustSeriesFirstIllust { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("illusts")]
        public IEnumerable<Illust> Illusts { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("next_url")]
        public Uri NextUrl { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}