using System.Threading.Tasks;

using Sagitta.Models;

namespace Sagitta.Clients
{
    public class NotificationUserClient : ApiClient
    {
        public NotificationUserClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task<Notification> TopicAsync()
        {
            return await PixivClient.GetAsync<Notification>("https://app-api.pixiv.net/v1/notification/user/topic", PixivClient.EmptyParameter);
        }
    }
}