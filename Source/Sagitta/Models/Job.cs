using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     職業
    /// </summary>
    public class Job
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