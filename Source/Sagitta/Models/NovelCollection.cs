using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class NovelCollection : Cursorable<NovelCollection>
    {
        [JsonProperty("novels")]
        public IEnumerable<Novel> Novels { get; set; }
    }
}