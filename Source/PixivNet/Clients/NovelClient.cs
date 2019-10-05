using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Enum;
using Pixiv.Extensions;
using Pixiv.Helpers;
using Pixiv.Models;

namespace Pixiv.Clients
{
    /// <summary>
    ///     小説関連 API
    /// </summary>
    public class NovelClient : ApiClient
    {
        /// <inheritdoc />
        internal NovelClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     フォローしているユーザーの投稿した小説を取得します。
        /// </summary>
        /// <param name="restrict">公開制限</param>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> FollowAsync(Restrict restrict = Restrict.All, long offset = 0)
        {
            Ensure.InvalidEnumValue(restrict == Restrict.Mypixiv, nameof(restrict));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("restrict", restrict.ToParameter()) };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/follow", parameters).Stay();
        }

        /// <summary>
        ///     マーキングしてある小説を取得します。
        /// </summary>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="MarkerCollection" />
        /// </returns>
        public async Task<MarkerCollection> MarkersAsync(long offset = 0)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<MarkerCollection>("https://app-api.pixiv.net/v2/novel/markers", parameters).Stay();
        }

        /// <summary>
        ///     マイピクユーザーの投稿した新着小説を取得します。
        /// </summary>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> MypixivAsync(long offset = 0)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/mypixiv", parameters).Stay();
        }

        /// <summary>
        ///     全ユーザーの投稿した新着小説を取得します。
        /// </summary>
        /// <param name="maxNovelId">最大小説 ID</param>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> NewAsync(long maxNovelId = 0)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (maxNovelId > 0)
                parameters.Add(new KeyValuePair<string, object>("max_novel_id", maxNovelId));

            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/new", parameters).Stay();
        }

        /// <summary>
        ///     おすすめ小説を取得します。
        /// </summary>
        /// <param name="includeRankingNovels">ランキング上位の小説をレスポンスに含むか</param>
        /// <param name="maxBookmarkIdForRecommend">TODO</param>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> RecommendedAsync(bool includeRankingNovels = false, long maxBookmarkIdForRecommend = 0, long offset = 0)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (includeRankingNovels)
                parameters.Add(new KeyValuePair<string, object>("include_ranking_novels", true));
            if (maxBookmarkIdForRecommend > 0)
                parameters.Add(new KeyValuePair<string, object>("max_bookmark_id_for_recommend", maxBookmarkIdForRecommend));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/recommend", parameters).Stay();
        }

        /// <summary>
        ///     ランキング上位の小説を取得します。
        /// </summary>
        /// <param name="mode">ランキングモード</param>
        /// <param name="date">日付 (YYYY-MM-DD 形式)</param>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> RankingAsync(RankingMode mode, string date = "", long offset = 0)
        {
            Ensure.InvalidEnumValue(mode == RankingMode.DailyManga, nameof(mode));
            Ensure.InvalidEnumValue(mode == RankingMode.WeeklyManga, nameof(mode));
            Ensure.InvalidEnumValue(mode == RankingMode.WeeklyOriginal, nameof(mode));
            Ensure.InvalidEnumValue(mode == RankingMode.Monthly, nameof(mode));
            Ensure.InvalidEnumValue(mode == RankingMode.MonthlyManga, nameof(mode));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("mode", mode.ToParameter()) };
            if (!string.IsNullOrWhiteSpace(date))
                parameters.Add(new KeyValuePair<string, object>("date", date));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/ranking", parameters).Stay();
        }

        /// <summary>
        ///     小説の本文情報を取得します。
        /// </summary>
        /// <param name="novelId">小説 ID</param>
        /// <returns>
        ///     <see cref="NovelText" />
        /// </returns>
        public async Task<NovelText> TextAsync(long novelId)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("novel_id", novelId) };

            return await PixivClient.GetAsync<NovelText>("https://app-api.pixiv.net/v1/novel/text", parameters).Stay();
        }
    }
}