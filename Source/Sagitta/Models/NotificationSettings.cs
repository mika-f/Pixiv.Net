using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     通知設定
    /// </summary>
    public class NotificationSettings : ApiResponse
    {
        /// <summary>
        ///     デバイスが登録済みであるか
        /// </summary>
        [JsonProperty("device_registered")]
        public bool IsDeviceRegistered { get; set; }

        /// <summary>
        ///     通知タイプのリスト
        /// </summary>
        [JsonProperty("types")]
        public IEnumerable<NotificationType> Types { get; set; }
    }
}