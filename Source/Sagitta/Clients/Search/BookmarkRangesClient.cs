using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients.Search
{
    /// <summary>
    ///     TODO
    /// </summary>
    public class BookmarkRangesClient : ApiClient
    {
        /// <inheritdoc />
        internal BookmarkRangesClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     TODO
        /// </summary>
        /// <param name="word">検索する単語</param>
        /// <param name="sort">ソート順</param>
        /// <param name="searchTarget">検索対象</param>
        /// <param name="bookmarkMinNum">TODO</param>
        /// <param name="startDate">開始日時</param>
        /// <param name="endDate">終了日時</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IEnumerable{BookmarkRange}" />
        /// </returns>
        public async Task<IEnumerable<BookmarkRange>> IllustAsync(string word, SortOrder sort, SearchTarget searchTarget, string bookmarkMinNum = "",
                                                                  string startDate = "", string endDate = "", string filter = "")
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));
            Ensure.InvalidEnumValue(searchTarget == SearchTarget.Keyword, nameof(searchTarget));
            Ensure.InvalidEnumValue(searchTarget == SearchTarget.Text, nameof(searchTarget));

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("word", word),
                new KeyValuePair<string, object>("sort", sort.ToParameter()),
                new KeyValuePair<string, object>("search_target", searchTarget.ToParameter())
            };
            if (!string.IsNullOrWhiteSpace(bookmarkMinNum))
                parameters.Add(new KeyValuePair<string, object>("bookmark_min_num", bookmarkMinNum));
            if (!string.IsNullOrWhiteSpace(startDate))
                parameters.Add(new KeyValuePair<string, object>("start_date", startDate));
            if (!string.IsNullOrWhiteSpace(endDate))
                parameters.Add(new KeyValuePair<string, object>("end_date", endDate));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/search/bookmark-ranges/illust", parameters).Stay();
            return response["bookmark_ranges"].ToObject<IEnumerable<BookmarkRange>>();
        }

        /// <summary>
        ///     TODO
        /// </summary>
        /// <param name="word">検索する単語</param>
        /// <param name="sort">ソート順</param>
        /// <param name="searchTarget">検索対象</param>
        /// <param name="bookmarkMinNum">TODO</param>
        /// <param name="startDate">開始日時</param>
        /// <param name="endDate">終了日時</param>
        /// <param name="filter">フィルター (`for_ios` が有効)</param>
        /// <returns>
        ///     <see cref="IEnumerable{BookmarkRange}" />
        /// </returns>
        public async Task<IEnumerable<BookmarkRange>> NovelAsync(string word, SortOrder sort, SearchTarget searchTarget, string bookmarkMinNum = "",
                                                                 string startDate = "", string endDate = "", string filter = "")
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("word", word),
                new KeyValuePair<string, object>("sort", sort.ToParameter()),
                new KeyValuePair<string, object>("search_target", searchTarget.ToParameter())
            };
            if (!string.IsNullOrWhiteSpace(bookmarkMinNum))
                parameters.Add(new KeyValuePair<string, object>("bookmark_min_num", bookmarkMinNum));
            if (!string.IsNullOrWhiteSpace(startDate))
                parameters.Add(new KeyValuePair<string, object>("start_date", startDate));
            if (!string.IsNullOrWhiteSpace(endDate))
                parameters.Add(new KeyValuePair<string, object>("end_date", endDate));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>("filter", filter));

            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/search/bookmark-ranges/novel", parameters).Stay();
            return response["bookmark_ranges"].ToObject<IEnumerable<BookmarkRange>>();
        }
    }
}