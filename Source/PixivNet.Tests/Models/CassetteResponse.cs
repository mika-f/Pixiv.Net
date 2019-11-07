using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;

namespace Pixiv.Tests.Models
{
    internal class CassetteResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [JsonProperty("status")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("headers")]
        public Dictionary<string, IEnumerable<string>> Headers { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}