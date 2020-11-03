using SuperSearcher.DomainEntities.Statistics;
using SuperSearcher.Repositories;
using SuperSearcher.Services.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuperSearcher.Services
{
    public class StatisticService : IStatisticService
    {
        private ISearchTermRepository searchTermRepository;

        public StatisticService(ISearchTermRepository searchTermRepository)
        {
            this.searchTermRepository = searchTermRepository;
        }

        public void AddSearchTerm(string text)
        {
            // only support stats on searchterms with text
            if (!string.IsNullOrWhiteSpace(text))
            {
                searchTermRepository.Add(new SearchTermEntity()
                {
                    Name = text
                });
            }
        }

        public MySearchStats GetStats()
        {
            var searchedTerms = searchTermRepository.GetAll();

            var regexContainsSymbols = new Regex("^[a-zA-Z0-9 ]*$");

            var mySearchStats = new MySearchStats();
            mySearchStats.SearchCount = searchedTerms.Length;
            mySearchStats.AverageLength = searchedTerms.Length > 0 ? searchedTerms.Average(x => x.Name.Length) : 0;
            mySearchStats.CountContainingSymbols = searchedTerms.Where(x => !regexContainsSymbols.IsMatch(x.Name)).Count();
            mySearchStats.CountContainingNumbers = searchedTerms.Where(x => x.Name.Any(letter => char.IsDigit(letter))).Count();

            return mySearchStats;
        }
    }
}