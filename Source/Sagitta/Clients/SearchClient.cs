using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class SearchClient : ApiClient
    {
        public SearchClient(PixivClient pixivClient) : base(pixivClient) {}

        /// <summary>
        ///     Get autocomplete keywords.
        /// </summary>
        /// <param name="word">Partial word</param>
        /// <returns></returns>
        public async Task<Autocomplete> Autocomplete(string word)
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("word", word)
            };
            return await PixivClient.GetAsync<Autocomplete>("https://app-api.pixiv.net/v1/search/autocomplete", parameters);
        }

        /// <summary>
        ///     Search illusts.
        /// </summary>
        /// <param name="word">Keyword</param>
        /// <param name="target">Search target.</param>
        /// <param name="order">Search result order by</param>
        /// <param name="duration">Search duration. If set to `null`, search all illusts.</param>
        /// <param name="filter"></param>
        /// <param name="offset">Offset index</param>
        /// <returns></returns>
        public async Task<IllustsRoot> IllustAsync(string word, SearchTarget target = SearchTarget.PartialMatchForTags, SortOrder order = SortOrder.DateAsc,
                                                   Duration? duration = null, string filter = "", int offset = 0)
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));
            if (target == SearchTarget.Text || target == SearchTarget.Keyword)
                throw new NotSupportedException($"`{nameof(target)}`: {target} is not supported.");
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("search_target", target.ToParameterStr()),
                new KeyValuePair<string, string>("sort", order.ToParameterString()),
                new KeyValuePair<string, string>("word", word)
            };
            if (duration.HasValue)
                parameters.Add(new KeyValuePair<string, string>("duration", duration.Value.ToParameterStr()));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v1/search/illust", parameters);
        }

        public async Task<NovelsRoot> NovelAsync(string word, SearchTarget target = SearchTarget.PartialMatchForTags, SortOrder order = SortOrder.DateAsc,
                                                 Duration? duration = null, string filter = "", int offset = 0)
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));
            if (target == SearchTarget.TitleAndCaption || target == SearchTarget.ExactMatchForTags)
                throw new NotSupportedException($"`{nameof(target)}`: {target} is not supported.");
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("search_target", target.ToParameterStr()),
                new KeyValuePair<string, string>("sort", order.ToParameterString()),
                new KeyValuePair<string, string>("word", word)
            };
            if (duration.HasValue)
                parameters.Add(new KeyValuePair<string, string>("duration", duration.Value.ToParameterStr()));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<NovelsRoot>("https://app-api.pixiv.net/v1/search/novel", parameters);
        }

        public async Task<UserPreviewsRoot> UserAsync(string word, int offset = 0)
        {
            Ensure.NotNullOrWhitespace(word, nameof(word));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("word", word)
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<UserPreviewsRoot>("https://app-api.pixiv.net/v1/search/user", parameters);
        }
    }
}