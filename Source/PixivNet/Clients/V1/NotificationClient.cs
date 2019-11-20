using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class NotificationClient : ApiClient
    {
        internal NotificationClient(PixivClient client) : base(client, "/v1/notification") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NotificationSettings> SettingsAsync()
        {
            var response = await GetAsync("/settings").Stay();
            return response["notification_settings"]!.ToObject<NotificationSettings>()!;
        }
    }
}