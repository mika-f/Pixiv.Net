using System;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class Workspace : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("chair")]
        public string Chair { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("desk")]
        public string Desk { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("desktop")]
        public string Desktop { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("monitor")]
        public string Monitor { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("music")]
        public string Music { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("mouse")]
        public string Mouse { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("pc")]
        public string Pc { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("printer")]
        public string Printer { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("scanner")]
        public string Scanner { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("tablet")]
        public string Tablet { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("tool")]
        public string Tool { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("workspace_image_url")]
        public Uri WorkspaceImageUrl { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}