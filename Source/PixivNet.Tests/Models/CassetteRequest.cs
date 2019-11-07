using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Pixiv.Tests.Models
{
    internal class CassetteRequest
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("headers")]
        public Dictionary<string, IEnumerable<string>> Headers { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}