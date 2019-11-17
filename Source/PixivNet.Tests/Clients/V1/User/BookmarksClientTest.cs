using System.Threading.Tasks;

using Pixiv.Enums;

using Xunit;

namespace Pixiv.Tests.Clients.V1.User
{
    public class BookmarksClientTest : PixivTestAPiClient
    {
        public BookmarksClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Illust_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.Bookmarks.IllustAsync(3623925));
        }

        [Fact]
        public void Illust_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.Bookmarks.IllustAsync(3623925, Restrict.Public, null, null, null));
        }

        [Fact]
        public async Task Novel_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.Bookmarks.NovelAsync(3623925));
        }

        [Fact]
        public void Novel_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.Bookmarks.NovelAsync(3623925, Restrict.Public, null, null));
        }
    }
}