using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     プロフィールのプリセット情報
    /// </summary>
    public class ProfilePresets
    {
        /// <summary>
        ///     住所 (都道府県)
        /// </summary>
        [JsonProperty("addresses")]
        public IEnumerable<Address> Addresses { get; set; }

        /// <summary>
        ///     国
        /// </summary>
        [JsonProperty("countries")]
        public IEnumerable<Country> Countries { get; set; }

        /// <summary>
        ///     職業
        /// </summary>
        [JsonProperty("jobs")]
        public IEnumerable<Job> Jobs { get; set; }

        /// <summary>
        ///     デフォルトのプロフィール画像 URL
        /// </summary>
        [JsonProperty("default_profile_image_urls")]
        public ProfileImageUrls DefaultProfileImageUrls { get; set; }
    }
}