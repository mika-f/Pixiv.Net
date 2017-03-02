using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UserState
    {
        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }

        [JsonProperty("has_changed_pixiv_id")]
        public bool HasChangedPixivId { get; set; }

        [JsonProperty("can_change_pixiv_id")]
        public bool CanChangePixivId { get; set; }
    }
}