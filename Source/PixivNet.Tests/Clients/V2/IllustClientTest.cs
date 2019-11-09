using System.Threading.Tasks;

using Pixiv.Enum;

using Xunit;

namespace Pixiv.Tests.Clients.V2
{
    public class IllustClientTest : PixivTestAPiClient
    {
        [Fact]
        public async Task Comments_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV2.CommentsAsync(77607462));
        }

        [Fact]
        public void Comments_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV2.CommentsAsync(77607462, null));
        }

        [Fact]
        public async Task Follow_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV2.FollowAsync(Restrict.All));
        }

        [Fact]
        public void Follow_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV2.FollowAsync(Restrict.All, null));
        }

        [Fact]
        public async Task Mypixiv_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV2.MypixivAsync());
        }

        [Fact]
        public void Mypixiv_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV2.MypixivAsync(null));
        }

        [Fact]
        public async Task Related_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV2.RelatedAsync(52274754));
        }

        [Fact]
        public void Related_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV2.RelatedAsync(52274754, "for_ios", null, null));
        }

    }
}