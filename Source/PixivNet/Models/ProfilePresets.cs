using System.Collections.Generic;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class ProfilePresets : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("addresses")]
        public IEnumerable<Address> Addresses { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("countries")]
        public IEnumerable<Country> Countries { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("jobs")]
        public IEnumerable<Job> Jobs { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("default_profile_image_urls")]
        public ProfileImageUrls DefaultProfileImageUrls { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}