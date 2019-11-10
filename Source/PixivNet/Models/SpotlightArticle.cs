using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class SpotlightArticle : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("article_url")]
        public Uri ArticleUrl { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("category")]
        public string Category { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("publish_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime PublishDate { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("pure_title")]
        public string PureTitle { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("subcategory_label")]
        public string SubcategoryLabel { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("title")]
        public string Title { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}