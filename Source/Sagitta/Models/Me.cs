using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Me : UserMini
    {
        [JsonProperty("id")]
        public new string Id { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("mail_address")]
        public string MailAddress { get; set; }

        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        [JsonProperty("x_restrict")]
        public int Restrict { get; set; }

        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }
    }
}