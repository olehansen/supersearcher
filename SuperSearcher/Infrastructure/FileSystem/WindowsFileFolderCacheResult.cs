using SuperSearcher.DomainEntities.FilesAndFolders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SuperSearcher.Infrastructure.FileSystem
{
    public class WindowsFileFolderCacheResult
    {
        public FileEntity[] Files { get; set; }
        public FolderEntity[] Folders { get; set; }
    }
}
