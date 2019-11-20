using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class PPointClientTest : PixivTestAPiClient
    {
        public PPointClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Gains_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.PPoint.GainsAsync("ios"));
        }

        [Fact]
        public void Gains_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.PPoint.GainsAsync("ios"));
        }

        [Fact]
        public async Task Losses_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.PPoint.LossesAsync("ios"));
        }

        [Fact]
        public void Losses_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.PPoint.LossesAsync("ios"));
        }

        [Fact]
        public async Task Summary_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.PPoint.SummaryAsync("ios"));
        }

        [Fact]
        public void Summary_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.PPoint.SummaryAsync("ios"));
        }
    }
}