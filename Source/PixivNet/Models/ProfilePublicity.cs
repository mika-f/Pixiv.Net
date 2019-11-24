using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Attributes;
using Pixiv.Enums;

namespace Pixiv.Models
{
    public class ProfilePublicity : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("birth_day")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity BirthDay { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("birth_year")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity BirthYear { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity Gender { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("job")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity Job { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("pawoo")]
        public bool Pawoo { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("region")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity Region { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}