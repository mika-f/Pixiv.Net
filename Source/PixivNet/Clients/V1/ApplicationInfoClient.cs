using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class ApplicationInfoClient : ApiClient
    {
        public ApplicationInfoClient(PixivClient client) : base(client, "/v1/application-info") { }

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once InconsistentNaming
        [ApiVersion]
        [MarkedAs("7.7.7")]
        public async Task<ApplicationInfo> IOSAsync()
        {
            var obj = await GetAsync("/ios").Stay();
            return obj["application_info"].ToObject<ApplicationInfo>();
        }
    }
}