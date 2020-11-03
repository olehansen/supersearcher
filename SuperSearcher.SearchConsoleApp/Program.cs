using Microsoft.Extensions.DependencyInjection;
using SuperSearcher.Infrastructure.Dropbox;
using SuperSearcher.Infrastructure.Dropbox.repositories;
using SuperSearcher.Infrastructure.FileSystem;
using SuperSearcher.Infrastructure.Memory;
using SuperSearcher.Repositories;
using SuperSearcher.Services;
using System;

// TODO add documentation to some functions
// TODO add test data, for quick local test run

namespace SuperSearcher.SearchConsoleApp
{
    // https://www.codeguru.com/csharp/csharp/cs_misc/designtechniques/understanding-onion-architecture.html#:~:text=Onion%20Architecture%20is%20based%20on,on%20the%20actual%20domain%20models.

    class Program
    {
        static void writeLine(string line)
        {
            Console.WriteLine(line);
        }

        // root path, api
        static void Main(string[] args)
        {
            #region Args

            if (args.Length < 2)
            {
                writeLine("Args required: first folder path then dropbox access token");
                return;
            }

            var folderRootPath = args[0];
            var dropboxAccessToken = args[1];

            #endregion

            #region Dependency injection

            var dropboxRepositoryFactory = new DropboxRepositoryFactory(dropboxAccessToken);

            var serviceProvider = new ServiceCollection()
                .AddTransient<IDropboxFileRepository, DropboxFileRepository>(serviceProvider =>
                    {
                        return dropboxRepositoryFactory.CreateDropboxFilesRepository();
                    })
                .AddSingleton<IFileSystemRepository, WindowsFileSystemRepository>(serviceProvider =>
                    {
                        return new WindowsFileSystemRepository(folderRootPath);
                    })
                .AddSingleton<ISearchTermRepository, MemorySearchTermRepository>()
                .AddSingleton<IStatisticService, StatisticService>()
                .AddSingleton<ISuperSearcherService, SuperSearcherService>()
                .BuildServiceProvider();

            #endregion

            #region UI

            var superSearcherService = serviceProvider.GetService<ISuperSearcherService>();
            var statisticService = serviceProvider.GetService<IStatisticService>();

            writeLine("Hello Dorothy and welcome to the supersearcher. To Exit write \"exit\" to see stats write \"stats\" or to search write "
                + "\"search [name of the file or folder you are looking for]\"");

            while (true)
            {
                var line = Console.ReadLine();

                if (line.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    writeLine("Goodbye");
                    break;
                }

                if (line.Equals("stats", StringComparison.OrdinalIgnoreCase))
                {
                    var mySearchStats = statisticService.GetStats();

                    writeLine(string.Format("Number of searches: {0}", mySearchStats.SearchCount));
                    writeLine(string.Format("Average length of searchterm: {0}", mySearchStats.AverageLength));
                    writeLine(string.Format("Seaches containing numbers: {0}", mySearchStats.CountContainingNumbers));
                    writeLine(string.Format("Searches containing symbols: {0}", mySearchStats.CountContainingSymbols));
                }
                else if (line.StartsWith("search"))
                {
                    var searchTerm = line.Substring(6).Trim();
                    var searchResult = superSearcherService.SearchByText(searchTerm);

                    if (searchResult.Items.Length == 0)
                    {
                        writeLine("no result found on : " + searchTerm);
                    }
                    else
                    {
                        foreach (var item in searchResult.Items)
                        {
                            writeLine(item.ToString());
                        }
                    }
                }
                else
                {
                    writeLine("I did not understand that, please try again");
                }
            }

            #endregion
        }
    }
}