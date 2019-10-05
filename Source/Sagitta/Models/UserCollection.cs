using System.Collections.Generic;

using Newtonsoft.Json;

namespace Pixiv.Models
{
    /// <summary>
    ///     ページング可能なユーザーのリスト
    /// </summary>
    public class UserCollection : Cursorable<UserCollection>
    {
        /// <summary>
        ///     ユーザーのリスト
        /// </summary>
        [JsonProperty("users")]
        public IEnumerable<User> Users { get; set; }
    }
}