using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class IllustSeriesClientTest : PixivTestAPiClient
    {
        [Fact]
        public async Task Illust_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.IllustSeries.IllustAsync(64230962));
        }

        [Fact]
        public void Illust_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.IllustSeries.IllustAsync(64230962, "for_ios"));
        }
    }
}