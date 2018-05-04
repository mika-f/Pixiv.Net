using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     オーナー
    /// </summary>
    public class Owner
    {
        /// <summary>
        ///     オーナー
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
    }
}