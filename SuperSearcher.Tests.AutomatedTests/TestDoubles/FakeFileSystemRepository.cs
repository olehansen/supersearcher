using SuperSearcher.DomainEntities.FilesAndFolders;
using SuperSearcher.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Tests.AutomatedTests.TestDoubles
{
    public class FakeFileSystemRepository : IFileSystemRepository
    {
        private FileEntity createTestFileEntity(string name)
        {
            return new FileEntity()
            {
                Name = name
            };
        }
        private FolderEntity createTestFolderEntity(string name)
        {
            return new FolderEntity()
            {
                Name = name
            };
        }

        public FileEntity[] GetAllFiles()
        {
            return new FileEntity[] {
                createTestFileEntity("testfile1.txt"),
                createTestFileEntity("testfile2.txt"),
                createTestFileEntity("testfile3.txt"),
                createTestFileEntity("testfile4.txt"),
                createTestFileEntity("testfile5.txt"),
                createTestFileEntity("testfile6.txt")
            };
        }

        public FolderEntity[] GetAllFolders()
        {
            return new FolderEntity[] {
                createTestFolderEntity("testfolder1.txt"),
                createTestFolderEntity("testfolder2.txt"),
                createTestFolderEntity("testfolder3.txt"),
                createTestFolderEntity("testfolder4.txt"),
                createTestFolderEntity("testfolder5.txt"),
                createTestFolderEntity("testfolder6.txt")
            };
        }
    }
}
