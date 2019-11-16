using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class IllustCollection : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("illusts")]
        public IEnumerable<Illust> Illusts { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("privacy_policy")]
        public PrivacyPolicy? PrivacyPolicy { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("ranking_illusts")]
        public IEnumerable<Illust>? RankingIllusts { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("search_span_limit")]
        public long? SearchSpanLimit { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("next_url")]
        public Uri? NextUrl { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}