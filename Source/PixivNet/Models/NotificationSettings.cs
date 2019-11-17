using System.Collections.Generic;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class NotificationSettings : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("device_registered")]
        public bool IsDeviceRegistered { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("types")]
        public IEnumerable<NotificationType> Types { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}