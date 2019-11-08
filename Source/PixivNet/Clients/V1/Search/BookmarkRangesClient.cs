using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Enum;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1.Search
{
    public class BookmarkRangesClient : ApiClient
    {
        internal BookmarkRangesClient(PixivClient client) : base(client, "/v1/search/bookmark-ranges") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IEnumerable<BookmarkRange>> IllustAsync(string word, SearchTarget searchTarget, Sort sort, long? bookmarkNumMax = null, long? bookmarkNumMin = null, bool includeTranslatedTagResults = true, bool mergePlainKeywordResults = true, DateTime? startDate = null, DateTime? endDate = null, string filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("include_translated_tag_results", includeTranslatedTagResults),
                new KeyValuePair<string, object>("merge_plain_keyword_results", mergePlainKeywordResults),
                new KeyValuePair<string, object>("search_target", searchTarget.ToValue()),
                new KeyValuePair<string, object>(nameof(sort), sort.ToValue()),
                new KeyValuePair<string, object>(nameof(word), word),
            };
            
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));
            if (bookmarkNumMax.HasValue)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_max", bookmarkNumMax.Value));
            if (bookmarkNumMin.HasValue)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_min", bookmarkNumMin.Value));
            if (endDate.HasValue)
                parameters.Add(new KeyValuePair<string, object>("end_date", endDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            if (startDate.HasValue)
                parameters.Add(new KeyValuePair<string, object>("start_date", startDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));

            var response = await this.GetAsync("/illust", parameters).Stay();
            return response["bookmark_ranges"].ToObject<IEnumerable<BookmarkRange>>();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IEnumerable<BookmarkRange>> NovelAsync(string word, SearchTarget searchTarget, Sort sort, long? bookmarkNumMax = null, long? bookmarkNumMin = null, bool includeTranslatedTagResults = true, bool mergePlainKeywordResults = true, DateTime? startDate = null, DateTime? endDate = null, string filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("include_translated_tag_results", includeTranslatedTagResults),
                new KeyValuePair<string, object>("merge_plain_keyword_results", mergePlainKeywordResults),
                new KeyValuePair<string, object>("search_target", searchTarget.ToValue()),
                new KeyValuePair<string, object>(nameof(sort), sort.ToValue()),
                new KeyValuePair<string, object>(nameof(word), word),
            };
            
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));
            if (bookmarkNumMax.HasValue)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_max", bookmarkNumMax.Value));
            if (bookmarkNumMin.HasValue)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_min", bookmarkNumMin.Value));
            if (endDate.HasValue)
                parameters.Add(new KeyValuePair<string, object>("end_date", endDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            if (startDate.HasValue)
                parameters.Add(new KeyValuePair<string, object>("start_date", startDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));

            var response = await this.GetAsync("/novel", parameters).Stay();
            return response["bookmark_ranges"].ToObject<IEnumerable<BookmarkRange>>();
        }
    }
}