using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Clients.V1.Search;
using Pixiv.Enum;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class SearchClient : ApiClient
    {
        public BookmarkRangesClient BookmarkRanges { get; }

        internal SearchClient(PixivClient client) : base(client, "/v1/search")
        {
            BookmarkRanges = new BookmarkRangesClient(client);
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> IllustAsync(string word, SearchTarget searchTarget, Sort sort, bool includeTranslatedTagResults = true, bool mergePlainKeywordResults = true, long? bookmarkNumMax = null, long? bookmarkNumMin = null, DateTime? startDate = null, DateTime? endDate = null,
                                                        long? offset = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(word), word),
                new KeyValuePair<string, object>("search_target", searchTarget.ToValue()),
                new KeyValuePair<string, object>(nameof(sort), sort.ToValue()),
                new KeyValuePair<string, object>("include_translated_tag_results", includeTranslatedTagResults),
                new KeyValuePair<string, object>("merge_plain_keyword_results", mergePlainKeywordResults)
            };
            if (bookmarkNumMax.HasValue)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_max", bookmarkNumMax.Value));
            if (bookmarkNumMin.HasValue)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_min", bookmarkNumMin));
            if (startDate.HasValue)
                parameters.Add(new KeyValuePair<string, object>("start_date", startDate.Value.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture)));
            if (endDate.HasValue)
                parameters.Add(new KeyValuePair<string, object>("end_date", endDate.Value.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture)));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<IllustCollection>("/illust", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> NovelAsync(string word, SearchTarget searchTarget, Sort sort, bool includeTranslatedTagResults = true, bool mergePlainKeywordResults = true, long? bookmarkNumMax = null, long? bookmarkNumMin = null, DateTime? startDate = null, DateTime? endDate = null,
                                                      long? offset = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(word), word),
                new KeyValuePair<string, object>("search_target", searchTarget.ToValue()),
                new KeyValuePair<string, object>(nameof(sort), sort.ToValue()),
                new KeyValuePair<string, object>("include_translated_tag_results", includeTranslatedTagResults),
                new KeyValuePair<string, object>("merge_plain_keyword_results", mergePlainKeywordResults)
            };
            if (bookmarkNumMax.HasValue)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_max", bookmarkNumMax.Value));
            if (bookmarkNumMin.HasValue)
                parameters.Add(new KeyValuePair<string, object>("bookmark_num_min", bookmarkNumMin));
            if (startDate.HasValue)
                parameters.Add(new KeyValuePair<string, object>("start_date", startDate.Value.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture)));
            if (endDate.HasValue)
                parameters.Add(new KeyValuePair<string, object>("end_date", endDate.Value.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture)));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<NovelCollection>("/novel", parameters).Stay();
        }
    }
}