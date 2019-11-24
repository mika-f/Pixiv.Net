using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class NotificationClientTest : PixivTestAPiClient
    {
        public NotificationClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Settings_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Notification.SettingsAsync());
        }

        [Fact]
        public void Settings_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Notification.SettingsAsync());
        }
    }
}