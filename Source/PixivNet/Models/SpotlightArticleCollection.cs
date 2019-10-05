using System.Collections.Generic;

using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     ページング可能な Pixivision (旧 pixiv Spotlight) の記事リスト
    /// </summary>
    public class SpotlightArticleCollection : Cursorable<SpotlightArticleCollection>
    {
        /// <summary>
        ///     記事リスト
        /// </summary>
        [JsonProperty("spotlight_articles")]
        public IEnumerable<SpotlightArticle> SpotlightArticles { get; set; }
    }
}