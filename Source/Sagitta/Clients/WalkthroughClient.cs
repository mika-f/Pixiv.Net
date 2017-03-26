using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class WalkthroughClient : ApiClient
    {
        public WalkthroughClient(PixivClient pixivClient) : base(pixivClient) {}

        public Task<IllustCollection> IllustsAsync()
        {
            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/walkthrough/illusts", PixivClient.EmptyParameter, false);
        }
    }
}