using SuperSearcher.DomainEntities.Statistics;
using SuperSearcher.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Tests.AutomatedTests.TestDoubles
{
    public class SubSearchTermRepository : ISearchTermRepository
    {
        private List<SearchTermEntity> terms = new List<SearchTermEntity>();

        public void Add(SearchTermEntity searchTerm)
        {           
            terms.Add(searchTerm);
        }

        public SearchTermEntity[] GetAll()
        {
            return terms.ToArray();
        }
    }
}
