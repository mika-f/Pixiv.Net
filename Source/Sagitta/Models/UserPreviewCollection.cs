using System.Collections.Generic;

using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     ページング可能なプレビュー可能なユーザーの一覧
    /// </summary>
    public class UserPreviewCollection : Cursorable<UserPreviewCollection>

    {
        [JsonProperty("user_previews")]
        public IEnumerable<UserPreview> UserPreviews { get; set; }
    }
}