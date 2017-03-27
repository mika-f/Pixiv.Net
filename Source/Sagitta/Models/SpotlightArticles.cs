using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class SpotlightArticles : Cursorable<SpotlightArticles>
    {
        [JsonProperty("spotlight_articles")]
        public IEnumerable<SpotlightArticle> Articles { get; set; }
    }
}