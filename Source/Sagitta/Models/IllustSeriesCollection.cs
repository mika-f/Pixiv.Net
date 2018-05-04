using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     イラストのシリーズ
    /// </summary>
    public class IllustSeriesCollection : Cursorable<IllustSeriesCollection>
    {
        /// <summary>
        ///     シリーズ詳細
        /// </summary>
        [JsonProperty("illust_series_detail")]
        public Series IllustSeriesDetail { get; set; }

        /// <summary>
        ///     シリーズ最初の作品
        /// </summary>
        [JsonProperty("illust_series_first_illust")]
        public Illust FirstIllust { get; set; }

        /// <summary>
        ///     イラスト一覧
        /// </summary>
        [JsonProperty("illuss")]
        public IEnumerable<Illust> Illusts { get; set; }
    }
}