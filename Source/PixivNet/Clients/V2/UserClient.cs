using Pixiv.Clients.V2.User;

namespace Pixiv.Clients.V2
{
    public class UserClient : ApiClient
    {
        public BrowsingHistoryClient BrowsingHistory { get; }
        
        internal UserClient(PixivClient client) : base(client, "/v2/user")
        {
            BrowsingHistory = new BrowsingHistoryClient(client);
        }
    }
}