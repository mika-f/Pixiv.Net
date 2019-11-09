using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1.User
{
    public class MeClientTest : PixivTestAPiClient
    {
        [Fact]
        public async Task State_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.Me.StateAsync());
        }

        [Fact]
        public void State_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.Me.StateAsync());
        }
    }
}