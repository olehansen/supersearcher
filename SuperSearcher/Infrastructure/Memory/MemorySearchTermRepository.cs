using Microsoft.Extensions.Caching.Memory;
using SuperSearcher.DomainEntities.Statistics;
using SuperSearcher.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Infrastructure.Memory
{
    public class MemorySearchTermRepository : ISearchTermRepository
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