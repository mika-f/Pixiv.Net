using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class MinifiedUser : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("account")]
        public string Account { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_followed")]
        public bool IsFollowed { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("profile_image_urls")]
        public ProfileImageUrls ProfileImageUrls { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}