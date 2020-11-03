using SuperSearcher.DomainEntities.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Repositories
{
    public interface ISearchTermRepository
    {
        void Add(SearchTermEntity searchTerm);
        SearchTermEntity[] GetAll();
    }
}
