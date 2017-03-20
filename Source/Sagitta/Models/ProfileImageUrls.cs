using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class ProfileImageUrls
    {
        [JsonProperty("medium")]
        public string Medium { get; set; }

        /// <summary>
        ///     16x16
        /// </summary>
        [JsonProperty("px_16x16")]
        public string Small { get; set; }

        [JsonProperty("px_50x50")]
        private string MediumInternal
        {
            get { return Medium; }
            set { Medium = value; }
        }

        [JsonProperty("px_170x170")]
        public string Large { get; set; }
    }
}