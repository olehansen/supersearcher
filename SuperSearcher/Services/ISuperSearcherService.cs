using SuperSearcher.Infrastructure.Dropbox;
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
    public interface ISuperSearcherService
    {
        SearchResult SearchByText(string text);
    }
}
