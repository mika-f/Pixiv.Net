using System.Collections.Generic;

using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     ページング可能なイラストのリスト
    /// </summary>
    public class IllustCollection : Cursorable<IllustCollection>
    {
        /// <summary>
        ///     イラストのリスト
        /// </summary>
        [JsonProperty("illusts")]
        public IEnumerable<Illust> Illusts { get; set; }

        /// <summary>
        ///     ランキング上位のイラストのリスト
        /// </summary>
        [JsonProperty("ranking_illusts")]
        public IEnumerable<Illust> RankingIllusts { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("search_span_limit")]
        public int SearchSpanLimit { get; set; }
    }
}