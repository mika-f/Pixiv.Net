using System.Threading.Tasks;

using Pixiv.Enum;

using Xunit;

namespace Pixiv.Tests.Clients.V2.Illust
{
    public class BookmarkClientTest : PixivTestAPiClient
    {
        [Fact]
        public void Add_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV2.Bookmark.AddAsync(75936921, Restrict.Public));
        }

        [Fact]
        public async Task Add_ShouldRequestIsSuccess()
        {
            await ShouldRequestIsSuccess(w => w.IllustV2.Bookmark.AddAsync(77676356));
        }

        [Fact]
        public async Task Detail_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV2.Bookmark.DetailAsync(77523005));
        }

        [Fact]
        public void Detail_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV2.Bookmark.DetailAsync(77523005));
        }
    }
}