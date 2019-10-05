using System.Collections.Generic;

using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     ページング可能な小説のリスト
    /// </summary>
    public class NovelCollection : Cursorable<NovelCollection>
    {
        /// <summary>
        ///     小説のリスト
        /// </summary>
        [JsonProperty("novels")]
        public IEnumerable<Novel> Novels { get; set; }

        /// <summary>
        ///     ランキング上位の小説のリスト
        /// </summary>
        [JsonProperty("ranking_novels")]
        public IEnumerable<Novel> RankingNovels { get; set; }
    }
}