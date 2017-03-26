using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class MuteClient : ApiClient
    {
        public MuteClient(PixivClient pixivClient) : base(pixivClient) {}

        public Task<MuteList> ListAsync()
        {
            return PixivClient.GetAsync<MuteList>("https://app-api.pixiv.net/v1/mute/list", PixivClient.EmptyParameter);
        }
    }
}