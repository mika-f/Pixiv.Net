using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.Auth
{
    public class AuthenticationClientTest : PixivTestAPiClient
    {
        [Fact]
        public async Task Login_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Authentication.LoginAsync("**", "**", "ad11f91d202e79b1e1bd1e63df42b85f"));
        }

        [Fact]
        public void Login_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Authentication.LoginAsync("", "", ""));
        }
    }
}