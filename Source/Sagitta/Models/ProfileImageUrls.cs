using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     Profile Image Urls
    /// </summary>
    public class ProfileImageUrls : ApiResponse
    {
        /// <summary>
        ///     Medium (170x170) image url
        /// </summary>
        [JsonProperty("medium")]
        public string Medium { get; set; }

        /// <summary>
        ///     Smallest (16x16) image url
        /// </summary>
        [JsonProperty("px_16x16")]
        public string Square16 { get; set; }

        /// <summary>
        ///     Smaller (50x50) image url
        /// </summary>
        [JsonProperty("px_50x50")]
        public string Square50 { get; set; }

        /// <summary>
        ///     Medium (170x170) image url
        /// </summary>
        [JsonProperty("px_170x170")]
        public string Square170 { get; set; }
    }
}