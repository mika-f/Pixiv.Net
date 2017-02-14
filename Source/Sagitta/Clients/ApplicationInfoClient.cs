using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class ApplicationInfoClient : ApiClient
    {
        public ApplicationInfoClient(PixivClient pixivClient) : base(pixivClient) {}

        // ReSharper disable once InconsistentNaming
        public async Task<ApplicationInfo> iOSAsync()
        {
            var response = await PixivClient.GetAsync<ApplicationInfoResponse>("https://app-api.pixiv.net/v1/application-info/ios", PixivClient.EmptyParameter);
            return response.ApplicationInfo;
        }
    }
}