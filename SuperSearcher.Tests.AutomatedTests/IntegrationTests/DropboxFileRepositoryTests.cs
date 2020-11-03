using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSearcher.Infrastructure.Dropbox;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.Tests.AutomatedTests.IntegrationTests
{
    [TestClass]
    public class DropboxFileRepository
    {
        [TestMethod]
        public async Task Search()
        {
            var dropboxRepositoryFactory = new DropboxRepositoryFactory(FyFy.DropboxDevAccessToken);
            var dropboxFilesRepository = dropboxRepositoryFactory.CreateDropboxFilesRepository();

            var dropboxMax3Files = await dropboxFilesRepository.Search("Test", 3);
            var dropboxMax5Files = await dropboxFilesRepository.Search("Test", 5);

            Assert.IsTrue(dropboxMax3Files.Any() && dropboxMax5Files.Any(), "Not all searches returned files: max 3 = " + dropboxMax3Files.Length + " max 5 = " + dropboxMax5Files.Length);
            Assert.IsTrue(dropboxMax3Files.Length == 3, "max_results did not limit result to 3");
            Assert.IsTrue(dropboxMax5Files.Length == 5, "max_results did not limit result to 3");
        }
    }
}
