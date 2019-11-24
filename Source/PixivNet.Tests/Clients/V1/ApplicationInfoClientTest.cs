using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class ApplicationInfoClientTest : PixivTestAPiClient
    {
        // ReSharper disable once InconsistentNaming
        [Fact]
        public async Task IOS_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.ApplicationInfo.IOSAsync());
        }

        // ReSharper disable once InconsistentNaming
        [Fact]
        public void IOS_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.ApplicationInfo.IOSAsync());
        }
    }
}