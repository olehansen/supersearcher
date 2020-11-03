using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.DomainEntities.FilesAndFolders
{
    public class FolderEntity : FileOrFolderEntity
    {
        public int NumberOfFiles { get; set; }
    }
}