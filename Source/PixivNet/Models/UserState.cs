using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class UserState : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("can_change_pixiv_id")]
        public bool CanChangePixivId { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("has_changed_pixiv_id")]
        public bool HasChangedPixivId { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}