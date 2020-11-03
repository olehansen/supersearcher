using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSearcher.Infrastructure.Dropbox;
using SuperSearcher.Services;
using SuperSearcher.Tests.AutomatedTests.TestDoubles;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.Tests.AutomatedTests.UnitTests
{
    [TestClass]
    public class SuperSearcherServiceTests
    {
        [TestMethod]
        public void SearchByTextTest()
        {
            var stubStatisticService = new StubStatisticService();

            var superSearcherService = new SuperSearcherService(
                new FakeDropboxFileRepository(),
                new FakeFileSystemRepository(),
                stubStatisticService);

            var text = "test";
            var result = superSearcherService.SearchByText(text);

            Assert.IsTrue(result.Items.Length == 9, "expected 9 items");

            // test if found files do contain "test"
            foreach (var item in result.Items)
            {
                Assert.IsTrue(item.Name.ToLower().Contains(text), item.Name + " did not contain text = " + text);
            }

            var dummy1Result = superSearcherService.SearchByText("dummy1");
            var dummy2Result = superSearcherService.SearchByText("dummy2");

            Assert.IsTrue(stubStatisticService.GetSearchTermCount() == 3, "expected 3 searches");
        }
    }
}
