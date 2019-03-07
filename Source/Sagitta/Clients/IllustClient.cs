using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sagitta.Clients.Illust;
using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    /// <summary>
    ///     イラスト関連 API
    /// </summary>
    public class IllustClient : ApiClient
    {
        /// <summary>
        ///     ブックマーク関連 API へのアクセサー
        /// </summary>
        public BookmarkClient Bookmark { get; }

        /// <summary>
        ///     コメント関連 API へのアクセサー
        /// </summary>
        public CommentClient Comment { get; }

        /// <inheritdoc />
        internal IllustClient(PixivClient pixivClient) : base(pixivClient)
        {
            Bookmark = new BookmarkClient(pixivClient);
            Comment = new CommentClient(pixivClient);
        }

        /// <summary>
        ///     指定したイラストのコメントを取得します。
        /// </summary>
        /// <param name="illustId">イラスト ID</param>
        /// <param name="lastCommentId">オフセット</param>
        /// <returns>
        ///     <see cref="CommentCollection" />
        /// </returns>
        public async Task<CommentCollection> CommentAsync(long illustId, long lastCommentId = 0)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("illust_id", illustId) };
            if (lastCommentId > 0)
                parameters.Add(new KeyValuePair<string, object>("last_comment_id", lastCommentId));

            return await PixivClient.GetAsync<CommentCollection>("https://app-api.pixiv.net/v2/illust/comments", parameters).Stay();
        }

        /// <summary>
        ///     指定したイラスト ID の詳細を取得します。
        /// </summary>
        /// <param name="illustId">イラスト ID</param>
        /// <returns>
        ///     <see cref="Models.Illust" />
        /// </returns>
        public async Task<Models.Illust> DetailAsync(long illustId)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("illust_id", illustId) };

            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/illust/detail", parameters).Stay();
            return response["illust"].ToObject<Models.Illust>();
        }

        /// <summary>
        ///     フォローしているユーザーの新着イラストを取得します。
        /// </summary>
        /// <param name="restrict">公開制限</param>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> FollowAsync(Restrict restrict = Restrict.All, long offset = 0)
        {
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("restrict", restrict.ToParameter()) };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v2/illust/follow", parameters).Stay();
        }

        /// <summary>
        ///     マイピクユーザーの新着イラストを取得します。
        /// </summary>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> MypixivAsync(long offset = 0)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v2/illust/mypixiv", parameters).Stay();
        }

        /// <summary>
        ///     新着イラストを取得します。
        /// </summary>
        /// <param name="contentType">イラストの種類</param>
        /// <param name="maxIllustId">最大イラスト ID</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> NewAsync(IllustType contentType, long maxIllustId = 0, string filter = "")
        {
            Ensure.InvalidEnumValue(contentType == IllustType.Ugoira, nameof(contentType));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("content_type", contentType.ToParameter()) };
            if (maxIllustId > 0)
                parameters.Add(new KeyValuePair<string, object>("max_illust_id", maxIllustId));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/illust/new", parameters).Stay();
        }

        /// <summary>
        ///     ランキング上位のイラスト一覧を取得します。
        /// </summary>
        /// <param name="mode">ランキングモード</param>
        /// <param name="date">YYYY-MM-DD 形式の日付</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> RankingAsync(RankingMode mode, string date = "", long offset = 0, string filter = "")
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("mode", mode.ToParameter()) };
            if (!string.IsNullOrWhiteSpace(date))
                parameters.Add(new KeyValuePair<string, object>("date", date));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/illust/ranking", parameters).Stay();
        }

        /// <summary>
        ///     おすすめのイラスト一覧を取得します。
        /// </summary>
        /// <param name="includeRankingIllusts">ランキング上位のイラストをレスポンスに含むか</param>
        /// <param name="minBookmarkIdForRecentIllust">TODO</param>
        /// <param name="maxBookmarkIdForRecommend">TODO</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> RecommendedAsync(bool includeRankingIllusts = false, long minBookmarkIdForRecentIllust = 0, long maxBookmarkIdForRecommend = 0, long offset = 0, string filter = "")
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (includeRankingIllusts)
                parameters.Add(new KeyValuePair<string, object>("include_ranking_illusts", true));
            if (minBookmarkIdForRecentIllust > 0)
                parameters.Add(new KeyValuePair<string, object>("min_bookmark_id_for_recent_illusts", minBookmarkIdForRecentIllust));
            if (maxBookmarkIdForRecommend > 0)
                parameters.Add(new KeyValuePair<string, object>("max_bookmark_id_for_recent_illust", maxBookmarkIdForRecommend));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/illust/recommended", parameters).Stay();
        }

        /// <summary>
        ///     指定したイラストに関連するイラストを取得します。
        /// </summary>
        /// <param name="illustId">イラスト ID</param>
        /// <param name="seedIllustIds">元となるイラスト ID</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustSeriesCollection" />
        /// </returns>
        public async Task<IllustCollection> RelatedAsync(long illustId, long[] seedIllustIds = null, string filter = "")
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("illust_id", illustId) };
            if (seedIllustIds?.Length > 0)
                parameters.AddRange(seedIllustIds.Select(seedIllustId => new KeyValuePair<string, object>("seed_illust_ids[]", seedIllustId)));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/illust/related", parameters).Stay();
        }

        /// <summary>
        ///     指定したシリーズ ID の詳細を取得します。
        /// </summary>
        /// <param name="illustSeriesId">シリーズ ID</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustSeriesCollection" />
        /// </returns>
        public async Task<IllustSeriesCollection> SeriesAsync(long illustSeriesId, long offset = 0, string filter = "")
        {
            Ensure.GreaterThanZero(illustSeriesId, nameof(illustSeriesId));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("illust_series_id", illustSeriesId) };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<IllustSeriesCollection>("https://app-api.pixiv.net/v1/illust/series", parameters).Stay();
        }
    }
}