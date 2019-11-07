using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class TrendingTagsClientTest : PixivTestAPiClient
    {
        [Fact]
        public async Task Illust_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.TrendingTags.IllustAsync());
        }

        [Fact]
        public void Illust_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.TrendingTags.IllustAsync("for_ios"));
        }

        [Fact]
        public async Task Novel_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.TrendingTags.NovelAsync());
        }

        [Fact]
        public void Novel_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.TrendingTags.NovelAsync("for_ios"));
        }
    }
}