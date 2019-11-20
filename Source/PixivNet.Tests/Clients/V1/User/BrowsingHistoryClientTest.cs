using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1.User
{
    public class BrowsingHistoryClientTest : PixivTestAPiClient
    {
        public BrowsingHistoryClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Illust_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.BrowsingHistory.IllustAsync());
        }

        [Fact]
        public void Illust_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.BrowsingHistory.IllustAsync(null));
        }

        [Fact]
        public async Task Novel_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.BrowsingHistory.NovelAsync());
        }

        [Fact]
        public void Novel_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.BrowsingHistory.NovelAsync(null));
        }
    }
}