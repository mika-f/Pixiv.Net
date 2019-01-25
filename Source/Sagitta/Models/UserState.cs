using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     認証ユーザーの現在の状態
    /// </summary>
    public class UserState : ApiResponse
    {
        /// <summary>
        ///     E-メール認証を終えているかどうか
        /// </summary>
        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }

        /// <summary>
        ///     pixiv ID を変更しているか
        /// </summary>
        [JsonProperty("has_changed_pixiv_id")]
        public bool HasChangedPixivId { get; set; }

        /// <summary>
        ///     pixiv ID を変更可能か
        /// </summary>
        [JsonProperty("can_change_pixiv_id")]
        public bool CanChangePixivId { get; set; }
    }
}