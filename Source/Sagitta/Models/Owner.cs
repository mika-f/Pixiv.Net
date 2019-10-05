using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     オーナー
    /// </summary>
    public class Owner : ApiResponse
    {
        /// <summary>
        ///     オーナー
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
    }
}