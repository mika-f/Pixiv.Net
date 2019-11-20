using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;

namespace Pixiv.Clients.V1.User
{
    public class WorkspaceClient : ApiClient
    {
        internal WorkspaceClient(PixivClient client) : base(client, "/v1/user/workspace") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task EditAsync(string chair = "", string comment = "", string desk = "", string desktop = "", string monitor = "", string mouse = "", string music = "", string pc = "", string printer = "", string scanner = "", string tablet = "", string tool = "")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(chair), chair),
                new KeyValuePair<string, object>(nameof(comment), comment),
                new KeyValuePair<string, object>(nameof(desk), desk),
                new KeyValuePair<string, object>(nameof(desktop), desktop),
                new KeyValuePair<string, object>(nameof(monitor), monitor),
                new KeyValuePair<string, object>(nameof(mouse), mouse),
                new KeyValuePair<string, object>(nameof(music), music),
                new KeyValuePair<string, object>(nameof(pc), pc),
                new KeyValuePair<string, object>(nameof(printer), printer),
                new KeyValuePair<string, object>(nameof(scanner), scanner),
                new KeyValuePair<string, object>(nameof(tablet), tablet),
                new KeyValuePair<string, object>(nameof(tool), tool)
            };

            await PostAsync("/edit", parameters).Stay();
        }
    }
}