using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sagitta.Models
{
    /// <summary>
    ///     シリーズ
    /// </summary>
    public class Series
    {
        /// <summary>
        ///     ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     タイトル
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     キャプション
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        ///     カバー画像 URL
        /// </summary>
        [JsonProperty("cover_imgage_urls")]
        public ImageUrls CoverImageUrls { get; set; }

        /// <summary>
        ///     シリーズに含まれる作品数
        /// </summary>
        [JsonProperty("series_work_count")]
        public int SeriesWorkCount { get; set; }

        /// <summary>
        ///     作成日時
        /// </summary>
        [JsonProperty("create_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     カバー画像横幅
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        ///     カバー画像高さ
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        ///     シリーズ投稿者
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
    }
}