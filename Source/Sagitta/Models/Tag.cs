using Newtonsoft.Json;

namespace Sagitta.Models
{
    /// <summary>
    ///     タグモデル
    /// </summary>
    public class Tag : ApiResponse
    {
        /// <summary>
        ///     名前
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     タグが投稿者によって付けられたものか否か
        /// </summary>
        [JsonProperty("added_by_uploaded_user")]
        public bool IsAddedByUploadedUser { get; set; }
    }
}