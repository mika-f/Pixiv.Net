using System.Threading.Tasks;

using Pixiv.Enums;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class NovelClientTest : PixivTestAPiClient
    {
        public NovelClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Follow_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Novel.FollowAsync(Restrict.All));
        }

        [Fact]
        public void Follow_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Novel.FollowAsync(Restrict.All, null));
        }

        [Fact]
        public async Task Mypixiv_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Novel.MypixivAsync());
        }

        [Fact]
        public void Mypixiv_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Novel.MypixivAsync(null));
        }

        [Fact]
        public async Task New_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Novel.NewAsync());
        }

        [Fact]
        public void New_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Novel.NewAsync(null));
        }

        [Fact]
        public async Task Ranking_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Novel.RankingAsync(RankingMode.Daily));
        }

        [Fact]
        public void Ranking_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Novel.RankingAsync(RankingMode.Daily, null, null));
        }

        [Fact]
        public async Task Recommended_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Novel.RecommendedAsync());
        }

        [Fact]
        public void Recommended_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Novel.RecommendedAsync(true, true, null, null));
        }
    }
}