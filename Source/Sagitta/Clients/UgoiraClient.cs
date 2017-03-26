using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class UgoiraClient : ApiClient
    {
        public UgoiraClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task<UgoiraMetadata> MetadataAsync(int illustId)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };
            var response = await PixivClient.GetAsync<UgoiraMetadataResponse>("https://app-api.pixiv.net/v1/ugoira/metadata", parameters).Stay();
            return response?.Metadata;
        }
    }
}