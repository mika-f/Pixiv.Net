using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Markers : Cursorable<Markers>
    {
        [JsonProperty("marked_novels")]
        public IEnumerable<Marker> MarkedNovels { get; set; }
    }
}