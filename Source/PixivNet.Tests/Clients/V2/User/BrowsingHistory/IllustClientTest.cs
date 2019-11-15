using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V2.User.BrowsingHistory
{
    public class IllustClientTest : PixivTestAPiClient
    {
        [Fact]
        public void Add_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV2.BrowsingHistory.Illust.AddAsync(new long[] { }));
        }

        [Fact]
        public async Task Add_ShouldRequestIsSuccess()
        {
            await ShouldRequestIsSuccess(w => w.UserV2.BrowsingHistory.Illust.AddAsync(new long[] { 77607462, 77612637 }));
        }
    }
}