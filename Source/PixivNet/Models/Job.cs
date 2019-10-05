using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     職業
    /// </summary>
    public class Job : ApiResponse
    {
        /// <summary>
        ///     ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     職業名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}