using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     プロフィール画像の URL
    /// </summary>
    public class ProfileImageUrls : ApiResponse
    {
        /// <summary>
        ///     中間サイズ (170x170) の画像 URL
        /// </summary>
        [JsonProperty("medium")]
        public string Medium { get; set; }
    }
}