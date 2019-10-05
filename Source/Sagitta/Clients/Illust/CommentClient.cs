using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients.Illust
{
    /// <summary>
    ///     コメント関連 API
    /// </summary>
    public class CommentClient : ApiClient
    {
        /// <inheritdoc />
        internal CommentClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     指定したコメント ID に対しての返信を取得します。
        /// </summary>
        /// <param name="commentId">コメント ID</param>
        /// <param name="offset" オフセット></param>
        /// <returns>
        ///     <see cref="CommentCollection" />
        /// </returns>
        public async Task<CommentCollection> RepliesAsync(long commentId, long offset = 0)
        {
            Ensure.GreaterThanZero(commentId, nameof(commentId));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("comment_id", commentId) };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<CommentCollection>("https://app-api.pixiv.net/v1/illust/comment/replies", parameters).Stay();
        }
    }
}