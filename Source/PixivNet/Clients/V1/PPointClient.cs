using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class PPointClient : ApiClient
    {
        // ReSharper disable once StringLiteralTypo
        internal PPointClient(PixivClient client) : base(client, "/v1/ppoint") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<GainsCollection> GainsAsync(string platform)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(platform), platform)
            };

            return await GetAsync<GainsCollection>("/gains", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<LossesCollection> LossesAsync(string platform)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(platform), platform)
            };

            return await GetAsync<LossesCollection>("/losses", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<PointSummary> SummaryAsync(string platform)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(platform), platform)
            };

            var response = await GetAsync("/summary", parameters).Stay();
            return response["summary"]!.ToObject<PointSummary>()!;
        }
    }
}