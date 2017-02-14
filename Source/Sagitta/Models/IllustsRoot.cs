using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class IllustsRoot
    {
        /// <summary>
        ///     Illusts
        /// </summary>
        [JsonProperty("illusts")]
        public IList<Illust> Illusts { get; set; }

        /// <summary>
        ///     Ranking illusts.
        ///     When set `include_ranking_illusts` to `false` or not set, this object is null.
        /// </summary>
        [JsonProperty("ranking_illusts")]
        public IList<Illust> RankingIllusts { get; set; }

        /// <summary>
        ///     Next page's query url.
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}