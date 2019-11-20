using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pixiv.Models
{
    public class ApiResponse
    {
#pragma warning disable CA2227 // コレクション プロパティは読み取り専用でなければなりません

        [JsonExtensionData]
        public IDictionary<string, JToken>? Extends { get; set; }

#pragma warning restore CA2227 // コレクション プロパティは読み取り専用でなければなりません
    }
}