using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ページング可能なブックマークタグのコレクション
    /// </summary>
    public class BookmarkTagCollection : Cursorable<BookmarkTagCollection>
    {
        /// <summary>
        ///     ブックマークタグのリスト
        /// </summary>
        [JsonProperty("bookmark_tags")]
        public IEnumerable<BookmarkTag> BookmarkTags { get; set; }
    }
}