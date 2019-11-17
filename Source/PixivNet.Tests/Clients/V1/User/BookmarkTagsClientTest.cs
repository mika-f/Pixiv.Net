using System.Threading.Tasks;

using Pixiv.Enum;

using Xunit;

namespace Pixiv.Tests.Clients.V1.User
{
    public class BookmarkTagsClientTest : PixivTestAPiClient
    {
        public BookmarkTagsClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Illust_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.BookmarkTags.IllustAsync(Restrict.Public));
        }

        [Fact]
        public void Illust_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.BookmarkTags.IllustAsync(Restrict.Public, null));
        }

        [Fact]
        public async Task Novel_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.BookmarkTags.NovelAsync(Restrict.Public));
        }

        [Fact]
        public void Novel_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.BookmarkTags.NovelAsync(Restrict.Public, null));
        }
    }
}