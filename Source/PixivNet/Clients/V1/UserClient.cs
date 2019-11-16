using Pixiv.Clients.V1.User;

namespace Pixiv.Clients.V1
{
    public class UserClient : ApiClient
    {
        public MeClient Me { get; }
        public ProfileClient Profile { get; }

        internal UserClient(PixivClient client) : base(client, "/v1/user")
        {
            Me = new MeClient(client);
            Profile = new ProfileClient(client);
        }
    }
}