using System;
using System.Threading.Tasks;

using Pixiv.Enum;

using Xunit;

namespace Pixiv.Tests.Clients.V1.Search
{
    public class BookmarkRangesClientTest : PixivTestAPiClient
    {
        [Fact]
        public async Task Illust_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.SearchV1.BookmarkRanges.IllustAsync("天気の子", SearchTarget.PartialMatchForTags, Sort.DateDesc));
        }

        [Fact]
        public void Illust_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.SearchV1.BookmarkRanges.IllustAsync(
                "", SearchTarget.TitleAndCaption, Sort.DateDesc, 
                0, 999, 
                true, true, 
                DateTime.Now, DateTime.Now, 
                "for_ios"));
        }

        [Fact]
        public async Task Novel_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.SearchV1.BookmarkRanges.NovelAsync("天気の子", SearchTarget.PartialMatchForTags, Sort.DateDesc));
        }

        [Fact]
        public void Novel_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.SearchV1.BookmarkRanges.NovelAsync(
                "", SearchTarget.TitleAndCaption, Sort.DateDesc,
                0, 999,
                true, true,
                DateTime.Now, DateTime.Now,
                "for_ios"));
        }
    }
}