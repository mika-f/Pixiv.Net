using System.Collections.Generic;

using Newtonsoft.Json;

using Pixiv.Attributes;

namespace Pixiv.Models
{
    public class PointSummary : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("expirations")]
        public IEnumerable<ApiResponse> Expirations { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("per_service_balances")]
        public IEnumerable<ApiResponse> PerServiceBalances { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}