using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace Sagitta.Models
{
    public class MyProfileImageUrls
    {
        [JsonProperty("px_16x16")]
        public string Square16px { get; set; }

        [JsonProperty("px_50x50")]
        public string Square50px { get; set; }

        [JsonProperty("px_170x170")]
        public string Square170px { get; set; }
    }
}