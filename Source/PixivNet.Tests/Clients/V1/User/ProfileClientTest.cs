using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1.User
{
    public class ProfileClientTest : PixivTestAPiClient
    {
        public ProfileClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Presets_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.Profile.PresetsAsync());
        }

        [Fact]
        public void Presets_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.Profile.PresetsAsync());
        }
    }
}