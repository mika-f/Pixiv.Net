using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Pixiv.Tests.Models
{
    internal class CassetteRequest
    {
        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("headers")]
        public Dictionary<string, IEnumerable<string>> Headers { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}