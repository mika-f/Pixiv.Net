using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1.User
{
    public class WorkspaceClientTest : PixivTestAPiClient
    {
        public WorkspaceClientTest() : base("**REDACTED**") { }

        [Fact]
        public void Edit_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.Workspace.EditAsync("", "", "", "", "", "", "", "", "", "", "", ""));
        }

        [Fact]
        public async Task Edit_ShouldRequestIsSuccess()
        {
            await ShouldRequestIsSuccess(w => w.UserV1.Workspace.EditAsync());
        }
    }
}