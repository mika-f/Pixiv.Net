using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Clients.Search;
using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    /// <summary>
    ///     検索関連 API
    /// </summary>
    public class SearchClient : ApiClient
    {
        /// <summary>
        ///     TODO
        /// </summary>
        public BookmarkRangesClient BookmarkRanges { get; }

        /// <inheritdoc />
        internal SearchClient(PixivClient pixivClient) : base(pixivClient)
        {
            BookmarkRanges = new BookmarkRangesClient(pixivClient);
        }

        /// <summary>
        ///     オートコンプリートようの文字列一覧を取得します。
        /// </summary>
        /// <param name="word">キーワード</param>
        /// <returns>
        ///     <see cref="IEnumerable{String}" />
        /// </returns>
        public async Task<IEnumerable<string>> AutocompleteAsync(string word)
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("word", word) };

            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/search/autocomplete", parameters).Stay();
            return response["search_auto_complete_keywords"].ToObject<IEnumerable<string>>();
        }

        /// <summary>
        ///     指定された条件に従ってイラストの検索を行います。
        /// </summary>
        /// <param name="word">検索ワード</param>
        /// <param name="searchTarget">検索対象</param>
        /// <param name="sort">ソート順</param>
        /// <param name="startDate">開始日時 (YYYY-MM-DD)</param>
        /// <param name="endDate">終了日時 (YYYY-MM-DD)</param>
        /// <param name="bookmarkNumMin">最小ブックマーク数</param>
        /// <param name="bookmarkNumMax">最大ブックマーク数</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IllustCollection" />
        /// </returns>
        public async Task<IllustCollection> IllustAsync(string word, SearchTarget searchTarget, SortOrder sort, string startDate = "", string endDate = "", int bookmarkNumMin = 0, int bookmarkNumMax = 0, long offset = 0, string filter = "")
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));
            Ensure.InvalidEnumValue(searchTarget == SearchTarget.Keyword, nameof(searchTarget));
            Ensure.InvalidEnumValue(searchTarget == SearchTarget.Text, nameof(searchTarget));

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("word", word),
                new KeyValuePair<string, object>("search_target", searchTarget.ToParameter()),
                new KeyValuePair<string, object>("sort", sort.ToParameter())
            };
            if (!string.IsNullOrWhiteSpace(startDate))
                parameters.Add(new KeyValuePair<string, object>("start_date", startDate));
            if (!string.IsNullOrWhiteSpace(endDate))
                parameters.Add(new KeyValuePair<string, object>("end_date", endDate));
            if (bookmarkNumMin > 0)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_min", bookmarkNumMin));
            if (bookmarkNumMax > 0)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_max", bookmarkNumMax));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/search/illust", parameters).Stay();
        }

        /// <summary>
        ///     指定された条件に従って小説の検索を行います。
        /// </summary>
        /// <param name="word">検索ワード</param>
        /// <param name="searchTarget">検索対象</param>
        /// <param name="sort">ソート順</param>
        /// <param name="startDate">開始日時 (YYYY-MM-DD)</param>
        /// <param name="endDate">終了日時 (YYYY-MM-DD)</param>
        /// <param name="bookmarkNumMin">最小ブックマーク数</param>
        /// <param name="offset">オフセット</param>
        /// <returns>
        ///     <see cref="NovelCollection" />
        /// </returns>
        public async Task<NovelCollection> NovelAsync(string word, SearchTarget searchTarget, SortOrder sort, string startDate = "", string endDate = "", int bookmarkNumMin = 0, long offset = 0)
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));
            Ensure.InvalidEnumValue(searchTarget == SearchTarget.Keyword, nameof(searchTarget));
            Ensure.InvalidEnumValue(searchTarget == SearchTarget.Text, nameof(searchTarget));

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("word", word),
                new KeyValuePair<string, object>("search_target", searchTarget.ToParameter()),
                new KeyValuePair<string, object>("sort", sort.ToParameter())
            };
            if (!string.IsNullOrWhiteSpace(startDate))
                parameters.Add(new KeyValuePair<string, object>("start_date", startDate));
            if (!string.IsNullOrWhiteSpace(endDate))
                parameters.Add(new KeyValuePair<string, object>("end_date", endDate));
            if (bookmarkNumMin > 0)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_min", bookmarkNumMin));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));

            return await PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/search/novel", parameters).Stay();
        }

        /// <summary>
        ///     ユーザーを検索します。
        /// </summary>
        /// <param name="word">検索ワード</param>
        /// <param name="offset">オフセット</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="UserPreviewCollection" />
        /// </returns>
        public async Task<UserPreviewCollection> UserAsync(string word, long offset = 0, string filter = "")
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("word", word) };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, object>("offset", offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            return await PixivClient.GetAsync<UserPreviewCollection>("https://app-api.pixiv.net/v1/search/user", parameters).Stay();
        }
    }
}