using System.Threading.Tasks;

using Pixiv.Enums;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class SearchClientTest : PixivTestAPiClient
    {
        public SearchClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Illust_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.SearchV1.IllustAsync("君の名は", SearchTarget.ExactMatchForTags, Sort.PopularDesc));
        }

        [Fact]
        public void Illust_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.SearchV1.IllustAsync("", SearchTarget.ExactMatchForTags, Sort.PopularDesc, true, true, null, null, null, null, null, null));
        }

        [Fact]
        public async Task Novel_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.SearchV1.NovelAsync("君の名は", SearchTarget.ExactMatchForTags, Sort.PopularDesc));
        }

        [Fact]
        public void Novel_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.SearchV1.NovelAsync("", SearchTarget.ExactMatchForTags, Sort.PopularDesc, true, true, null, null, null, null, null, null));
        }
    }
}