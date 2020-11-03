using SuperSearcher.DomainEntities;
using SuperSearcher.DomainEntities.Dropbox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperSearcher.Repositories
{
    public interface IDropboxFileRepository
    {
        Task<DropboxFileEntity[]> Search(string query, int max_results);
    }
}
