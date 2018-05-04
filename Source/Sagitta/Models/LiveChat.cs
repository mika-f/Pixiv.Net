using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     配信チャット
    /// </summary>
    public class LiveChat
    {
        /// <summary>
        ///     チャット ID
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     チャット送信者 ID
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        /// <summary>
        ///     チャット送信者
        /// </summary>
        [JsonProperty("user")]
        public LiveUser User { get; set; }

        /// <summary>
        ///     本文
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        ///     属性
        /// </summary>
        [JsonProperty("message_fragments")]
        public IEnumerable<MessageFragment> MessageFragments { get; set; }

        /// <summary>
        ///     送信日時
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}