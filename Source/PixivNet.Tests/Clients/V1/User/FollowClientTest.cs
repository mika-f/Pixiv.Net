using System.Threading.Tasks;

using Pixiv.Enums;

using Xunit;

namespace Pixiv.Tests.Clients.V1.User
{
    public class FollowClientTest : PixivTestAPiClient
    {
        public FollowClientTest() : base("**REDACTED**") { }

        [Fact]
        public void Add_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.Follow.AddAsync(11, Restrict.Public));
        }

        [Fact]
        public async Task Add_ShouldRequestIsSuccess()
        {
            await ShouldRequestIsSuccess(w => w.UserV1.Follow.AddAsync(11, Restrict.Public));
        }

        [Fact]
        public void Delete_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.Follow.DeleteAsync(11));
        }

        [Fact]
        public async Task Delete_ShouldRequestIsSuccess()
        {
            await ShouldRequestIsSuccess(w => w.UserV1.Follow.DeleteAsync(11));
        }
    }
}