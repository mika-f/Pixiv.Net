using System.Threading.Tasks;

using Xunit;

namespace Pixiv.Tests.Clients.V2
{
    public class SearchClientTest : PixivTestAPiClient
    {
        public SearchClientTest() : base("**REDACTED**") { }
        
        [Fact]
        public async Task AutoComplete_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.SearchV2.AutoCompleteAsync("ぼいす"));
        }

        [Fact]
        public void AutoComplete_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.SearchV2.AutoCompleteAsync("", true));
        }
    }
}