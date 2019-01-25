using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sagitta.Models
{
    /// <summary>
    ///     pixiv live
    /// </summary>
    public class Live : ApiResponse
    {
        /// <summary>
        ///     配信 ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     配信開始日時
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("performers")]
        public IEnumerable<User> Performers { get; set; }

        /// <summary>
        ///     配信タイトル
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("is_single")]
        public bool IsSingle { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("is_adult")]
        public bool IsAdult { get; set; }

        /// <summary>
        ///     R-18 か
        /// </summary>
        [JsonProperty("is_r18")]
        public bool IsR18 { get; set; }

        /// <summary>
        ///     R-15 か
        /// </summary>
        [JsonProperty("is_r15")]
        public bool IsR15 { get; set; }

        /// <summary>
        ///     公開制限
        /// </summary>
        [JsonProperty("publicity")]
        public string Publicity { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        /// <summary>
        ///     配信モード
        /// </summary>
        [JsonProperty("mode")]
        public string Mode { get; set; }

        /// <summary>
        ///     配信サーバー
        /// </summary>
        [JsonProperty("server")]
        public string Server { get; set; }

        /// <summary>
        ///     WebSocket チャンネル ID
        /// </summary>
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("is_enabled_mic_input")]
        public bool IsEnabledMicInput { get; set; }

        /// <summary>
        ///     サムネイル画像 URL
        /// </summary>
        [JsonProperty("thumbnail_image_url")]
        public string ThumbnailImageUrl { get; set; }

        /// <summary>
        ///     現在の視聴者数
        /// </summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        ///     累計視聴者数
        /// </summary>
        [JsonProperty("total_audience_count")]
        public int TotalAudienceCount { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("performance_count")]
        public int PerformanceCount { get; set; }

        /// <summary>
        ///     ミュートしているか
        /// </summary>
        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }
    }
}