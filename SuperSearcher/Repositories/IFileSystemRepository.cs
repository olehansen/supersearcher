using SuperSearcher.DomainEntities;
using SuperSearcher.DomainEntities.FilesAndFolders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperSearcher.Repositories
{
    public interface IFileSystemRepository
    {
        FileEntity[] GetAllFiles();
        FolderEntity[] GetAllFolders();
    }
}