using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class Myself : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("account")]
        public string? Account { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("mail_address")]
        public string MailAddress { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("profile_image_urls")]
        public ProfileImageUrls ProfileImageUrls { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("require_policy_agreement")]
        public bool RequirePolicyAgreement { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("x_restrict")]
        public int XRestrict { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}