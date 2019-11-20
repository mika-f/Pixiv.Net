using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1.Novel
{
    public class BookmarkClientTest : PixivTestAPiClient
    {
        public BookmarkClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Users_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Novel.Bookmark.UsersAsync(290299));
        }

        [Fact]
        public void Users_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Novel.Bookmark.UsersAsync(290299, null));
        }
    }
}