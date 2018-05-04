using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ページング可能なコメントのリスト
    /// </summary>
    public class CommentCollection : Cursorable<CommentCollection>
    {
        /// <summary>
        ///     コメントリスト
        /// </summary>
        [JsonProperty("comments")]
        public IEnumerable<Comment> Comments { get; set; }
    }
}