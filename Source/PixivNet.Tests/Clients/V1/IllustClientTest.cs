using System.Threading.Tasks;

using Pixiv.Enums;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class IllustClientTest : PixivTestAPiClient
    {
        public IllustClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Detail_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV1.DetailAsync(7551066));
        }

        [Fact]
        public void Detail_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV1.DetailAsync(7551066));
        }

        [Fact]
        public async Task New_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV1.NewAsync(ContentType.Illust));
        }

        [Fact]
        public void New_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV1.NewAsync(ContentType.Illust, null, null));
        }

        [Fact]
        public async Task Ranking_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV1.RankingAsync(RankingMode.Daily));
        }

        [Fact]
        public void Ranking_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV1.RankingAsync(RankingMode.Daily, null, null, null));
        }

        [Fact]
        public async Task Recommended_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustV1.RecommendedAsync());
        }

        [Fact]
        public void Recommended_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustV1.RecommendedAsync(true, true, null, null, null, null));
        }
    }
}