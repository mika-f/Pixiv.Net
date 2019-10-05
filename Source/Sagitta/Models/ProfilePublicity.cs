using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Enum;

namespace Pixiv.Models
{
    /// <summary>
    ///     プロフィールの公開状態
    /// </summary>
    public class ProfilePublicity : ApiResponse
    {
        /// <summary>
        ///     性別の公開状態
        /// </summary>
        [JsonProperty("gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrict Gender { get; set; }

        /// <summary>
        ///     地域の公開状態
        /// </summary>
        [JsonProperty("region")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrict Region { get; set; }

        /// <summary>
        ///     誕生日 (日付) の公開状態
        /// </summary>
        [JsonProperty("birth_day")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrict BirthDay { get; set; }

        /// <summary>
        ///     誕生日 (年) の公開情報
        /// </summary>
        [JsonProperty("birth_year")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrict BirthYear { get; set; }

        /// <summary>
        ///     職業の公開情報
        /// </summary>
        [JsonProperty("job")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrict Job { get; set; }

        /// <summary>
        ///     Pawoo の公開状態 (boolean)
        /// </summary>
        [JsonProperty("pawoo")]
        public bool IsPawooPublic { get; set; }
    }
}