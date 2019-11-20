using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V2
{
    public class UserClientTest : PixivTestAPiClient
    {
        public UserClientTest() : base("**REDACTED**") { }

        [Fact(Skip = "Unknown Object")]
        public async Task List_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV2.ListAsync());
        }

        [Fact]
        public void List_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV2.ListAsync("for_ios"));
        }
    }
}