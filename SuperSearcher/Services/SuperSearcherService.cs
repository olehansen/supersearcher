using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SuperSearcher.Repositories;
using SuperSearcher.DomainEntities;
using SuperSearcher.Services.SuperSearcher;

namespace SuperSearcher.Services
{
    public class SuperSearcherService : ISuperSearcherService
    {
        private IDropboxFileRepository dropboxFileRepository;
        private IFileSystemRepository fileSystemRepository;
        private IStatisticService statisticService;

        public bool hasBackgroundTask { get; set; }

        public SuperSearcherService(
            IDropboxFileRepository dropboxFileRepository,
            IFileSystemRepository fileSystemRepository,
            IStatisticService statisticService)
        {
            this.dropboxFileRepository = dropboxFileRepository;
            this.fileSystemRepository = fileSystemRepository;
            this.statisticService = statisticService;
        }

        /// <summary>
        /// Search after files or folders locally on you computer or in dropbox, that contains a searchterm.
        /// </summary>
        /// <param name="text">contains in item name</param>
        /// <returns>Returns max 9 items in a result object</returns>
        public SearchResult SearchByText(string text)
        {
            var addSearchTermTask = Task.Run(() =>
            {
                statisticService.AddSearchTerm(text);
            });

            int max_results = 3;
            var textToLower = text.ToLower();
            var dropboxTask = dropboxFileRepository.Search(textToLower, max_results);

            var items = new List<SearchItem>();

            items.AddRange(fileSystemRepository.GetAllFiles()
                .Where(x => x.Name.ToLower().Contains(textToLower))
                .Take(max_results)
                .Select(x => new SearchItem()
                {
                    Name = x.Name,
                    Type = SearchItemType.File
                }));

            items.AddRange(fileSystemRepository.GetAllFolders()
                .Where(x => x.Name.ToLower().Contains(textToLower))
                .Take(max_results)
                .Select(x => new SearchItem()
                {
                    Name = x.Name,
                    Type = SearchItemType.Folder
                }));

            // map DropboxFileEntity to a SearchItem when task is done
            items.AddRange(dropboxTask.Result.Select(x => new SearchItem()
            {
                Name = x.Name,
                Type = SearchItemType.Dropbox
            }));

            // added to ensure consistent test results
            addSearchTermTask.Wait();

            return new SearchResult() { Items = items.ToArray() };
        }
    }
}