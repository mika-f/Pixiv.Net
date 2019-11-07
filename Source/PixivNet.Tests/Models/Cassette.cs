using Newtonsoft.Json;

namespace Pixiv.Tests.Models
{
    internal class Cassette
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [JsonProperty("request")]
        public CassetteRequest Request { get; set; }

        [JsonProperty("response")]
        public CassetteResponse Response { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}