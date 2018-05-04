using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     ページング可能な生放送のリスト
    /// </summary>
    public class LiveCollection : Cursorable<LiveCollection>
    {
        /// <summary>
        ///     生放送リスト
        /// </summary>
        [JsonProperty("lives")]
        public IEnumerable<Live> Lives { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("live_info")]
        public object LiveInfo { get; set; }
    }
}