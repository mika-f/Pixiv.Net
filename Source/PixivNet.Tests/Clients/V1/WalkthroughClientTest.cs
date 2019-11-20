using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class WalkthroughClientTest : PixivTestAPiClient
    {
        [Fact]
        public async Task Illusts_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Walkthrough.IllustsAsync());
        }

        [Fact]
        public void Illusts_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Walkthrough.IllustsAsync());
        }
    }
}