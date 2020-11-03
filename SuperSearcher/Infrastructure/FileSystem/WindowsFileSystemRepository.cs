using SuperSearcher.DomainEntities.FilesAndFolders;
using SuperSearcher.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SuperSearcher.Infrastructure.FileSystem
{
    public class WindowsFileSystemRepository : IFileSystemRepository
    {
        private WindowsFileFolderCacheResult _cache;
        private object _cacheLock = new object();
        private string rootPath;

        public WindowsFileSystemRepository(string rootPath)
        {
            if (string.IsNullOrWhiteSpace(rootPath))
            {
                throw new Exception("rootPath is null or empty");
            }

            this.rootPath = rootPath;
        }

        private FileEntity mapToFileEntity(string filePath)
        {
            var fi = new FileInfo(filePath);
            return new FileEntity()
            {
                Name = fi.Name
            };
        }

        private FolderEntity mapToFolderEntity(string folderPath)
        {
            var di = new DirectoryInfo(folderPath);
            return new FolderEntity()
            {
                Name = di.Name,
                NumberOfFiles = di.GetFiles().Length
            };
        }

        private WindowsFileFolderCacheResult buildFolderOrFilesCache(string path)
        {
            var files = new List<FileEntity>();

            foreach (var file in Directory.GetFiles(path))
            {
                files.Add(mapToFileEntity(file));
            }

            var folders = new List<FolderEntity>();
            folders.Add(mapToFolderEntity(path));

            foreach (var subfolderFullName in Directory.GetDirectories(path))
            {
                var subFolderResult = buildFolderOrFilesCache(subfolderFullName);
                files.AddRange(subFolderResult.Files);
                folders.AddRange(subFolderResult.Folders);
            }

            var result = new WindowsFileFolderCacheResult();
            result.Files = files.ToArray();
            result.Folders = folders.ToArray();
            return result;
        }

        private WindowsFileFolderCacheResult GetCachedFilesAndFolders()
        {
            lock (_cacheLock)
            {
                if (_cache == null)
                {
                    _cache = buildFolderOrFilesCache(this.rootPath);
                }

                return _cache;
            }
        }

        public FileEntity[] GetAllFiles()
        {
            return GetCachedFilesAndFolders().Files;
        }

        public FolderEntity[] GetAllFolders()
        {
            return GetCachedFilesAndFolders().Folders;
        }
    }
}
