using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Sagitta.Enum;

namespace Sagitta.Models
{
    public class ProfilePublicity
    {
        [JsonProperty("gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity Gender { get; set; }

        [JsonProperty("region")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity Region { get; set; }

        [JsonProperty("birth_day")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity BirthDay { get; set; }

        [JsonProperty("birth_year")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity BirthYear { get; set; }

        [JsonProperty("job")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Publicity Job { get; set; }
    }
}