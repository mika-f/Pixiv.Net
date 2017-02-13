using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sagitta.Models
{
    public class SpotlightArticle
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pure_title")]
        public string PureTitle { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("article_url")]
        public string ArticleUrl { get; set; }

        [JsonProperty("publish_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("subcategory_label")]
        public string SubcategoryLabel { get; set; }
    }
}