using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sagitta.Models
{
    /// <summary>
    ///     Pixivision (旧 pixiv Spotlight) 個別記事
    /// </summary>
    public class SpotlightArticle : ApiResponse
    {
        /// <summary>
        ///     ID
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     タイトル
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     タイトル
        /// </summary>
        [JsonProperty("pure_title")]
        public string PureTitle { get; set; }

        /// <summary>
        ///     サムネイル画像 URL
        /// </summary>
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        /// <summary>
        ///     記事 URL
        /// </summary>
        [JsonProperty("article_url")]
        public string ArticleUrl { get; set; }

        /// <summary>
        ///     投稿日時
        /// </summary>
        [JsonProperty("publish_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime PublishDate { get; set; }

        /// <summary>
        ///     カテゴリー
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        ///     サブカテゴリー
        /// </summary>
        [JsonProperty("subcategory_label")]
        public string Subcategory { get; set; }
    }
}