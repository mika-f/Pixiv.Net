using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class IllustCollection : Cursorable<IllustCollection>
    {
        /// <summary>
        ///     Illusts
        /// </summary>
        [JsonProperty("illusts")]
        public IEnumerable<Illust> Illusts { get; set; }

        /// <summary>
        ///     Ranking illusts.
        ///     When set `include_ranking_illusts` to `false` or not set, this object is null.
        /// </summary>
        [JsonProperty("ranking_illusts")]
        public IEnumerable<Illust> RankingIllusts { get; set; }

        [JsonProperty("contest_exists")]
        public bool IsContestExists { get; set; }
    }
}