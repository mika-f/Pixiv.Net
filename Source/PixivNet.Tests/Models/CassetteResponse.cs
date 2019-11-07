using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;

namespace Pixiv.Tests.Models
{
    internal class CassetteResponse
    {
        [JsonProperty("status")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("headers")]
        public Dictionary<string, IEnumerable<string>> Headers { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}