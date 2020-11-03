using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSearcher.Infrastructure.Dropbox;
using SuperSearcher.Infrastructure.FileSystem;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SuperSearcher.Tests.AutomatedTests.IntegrationTests
{
    [TestClass]
    public class WindowsFileSystemRepositoryTests
    {
        private string pathToData;
        public WindowsFileSystemRepositoryTests()
        {
            pathToData = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"..\..\..\", "Data"));
        }

        [TestMethod]
        public void GetAllFiles()
        {
            var windowsFileSystemRepository = new WindowsFileSystemRepository(pathToData);
            var files = windowsFileSystemRepository.GetAllFiles();
            Assert.IsTrue(files.Length == 7, "expected 7 files");
        }

        public void GetAllFolders()
        {
            var windowsFileSystemRepository = new WindowsFileSystemRepository(pathToData);
            var folders = windowsFileSystemRepository.GetAllFolders();
            Assert.IsTrue(folders.Length == 7, "expected 7 folders");
        }
    }
}