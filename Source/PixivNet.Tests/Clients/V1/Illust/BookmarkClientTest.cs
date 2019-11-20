using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1.Illust
{
    public class BookmarkClientTest : PixivTestAPiClient
    {
        public BookmarkClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Users_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV1.Bookmark.UsersAsync(77520605));
        }

        [Fact]
        public void Users_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV1.Bookmark.UsersAsync(77520605, null));
        }
    }
}