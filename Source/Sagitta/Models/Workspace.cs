using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Workspace
    {
        [JsonProperty("pc")]
        // ReSharper disable once InconsistentNaming
        public string PC { get; set; }

        [JsonProperty("monitor")]
        public string Monitor { get; set; }

        [JsonProperty("tool")]
        public string Tool { get; set; }

        [JsonProperty("scanner")]
        public string Scanner { get; set; }

        [JsonProperty("tablet")]
        public string Tablet { get; set; }

        [JsonProperty("mouse")]
        public string Mouse { get; set; }

        [JsonProperty("printer")]
        public string Printer { get; set; }

        [JsonProperty("desktop")]
        public string Desktop { get; set; }

        [JsonProperty("music")]
        public string Music { get; set; }

        [JsonProperty("desk")]
        public string Desk { get; set; }

        [JsonProperty("chair")]
        public string Chair { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("workspace_image_url")]
        public string WorkspaceImageUrl { get; set; }
    }
}