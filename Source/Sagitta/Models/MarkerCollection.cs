using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ページング可能な小説マーカーのリスト
    /// </summary>
    public class MarkerCollection : Cursorable<MarkerCollection>
    {
        /// <summary>
        ///     マーカーリスト
        /// </summary>
        [JsonProperty("marked_novels")]
        public IEnumerable<MarkedNovel> MarkedNovels { get; set; }
    }
}