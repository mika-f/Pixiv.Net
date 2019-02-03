using Newtonsoft.Json;

namespace Sagitta.Models
{
    // MARKED: 7.4.4
    public class Me : ApiResponse
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }

        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        [JsonProperty("mail_address")]
        public string MailAddress { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_image_urls")]
        public ProfileImageUrls ProfileImageUrls { get; set; }

        [JsonProperty("require_policy_agreement")]
        public bool RequirePolicyAgreement { get; set; }

        [JsonProperty("x_restrict")]
        public int Restrict { get; set; }
    }
}