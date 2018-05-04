using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sagitta.Models
{
    /// <summary>
    ///     コメント
    /// </summary>
    public class Comment
    {
        /// <summary>
        ///     ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     コメント本文
        /// </summary>
        [JsonProperty("comment")]
        public string Text { get; set; }

        /// <summary>
        ///     投稿日時
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        ///     投稿者
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        ///     返信があるか
        /// </summary>
        [JsonProperty("has_replies")]
        public bool HasReplies { get; set; }
    }
}