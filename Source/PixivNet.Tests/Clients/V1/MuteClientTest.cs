using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class MuteClientTest : PixivTestAPiClient
    {
        public MuteClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task List_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.Mute.ListAsync());
        }

        [Fact]
        public void List_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.Mute.ListAsync());
        }
    }
}