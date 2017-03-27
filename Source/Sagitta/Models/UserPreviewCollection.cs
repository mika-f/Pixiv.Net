using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UserPreviewCollection : Cursorable<UserPreviewCollection>
    {
        [JsonProperty("user_previews")]
        public IEnumerable<UserPreview> UserPreviews { get; set; }
    }
}