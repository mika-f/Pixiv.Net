using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class SpotlightClientTest : PixivTestAPiClient
    {
        [Fact]
        public async Task Articles_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Spotlight.ArticlesAsync("all"));
        }

        [Fact]
        public void Articles_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Spotlight.ArticlesAsync("all", "for_ios", 0));
        }
    }
}