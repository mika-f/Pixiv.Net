using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class MangaClientTest : PixivTestAPiClient
    {
        public MangaClientTest() : base("**REDACTED**") { }

        [Fact]
        public void Recommend_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Manga.RecommendedAsync(new List<long>(), true, "for_ios", true, null, null));
        }

        [Fact]
        public async Task Recommended_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Manga.RecommendedAsync(new List<long> { 75059930, 74933665, 74670111, 74579299, 74579732, 71992158, 70531648, 70523868, 70430079, 69248283 }, true));
        }
    }
}