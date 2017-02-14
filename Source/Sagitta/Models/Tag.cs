using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("added_by_uploaded_user")]
        public bool AddedByUploadedUser { get; set; }
    }
}