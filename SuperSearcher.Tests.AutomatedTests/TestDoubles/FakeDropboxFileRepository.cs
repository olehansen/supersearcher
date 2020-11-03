using SuperSearcher.DomainEntities.Dropbox;
using SuperSearcher.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSearcher.Tests.AutomatedTests.TestDoubles
{
    public class FakeDropboxFileRepository : IDropboxFileRepository
    {
        private DropboxFileEntity createTestDropboxFileEntity(string name)
        {
            return new DropboxFileEntity()
            {
                Name = name
            };
        }

        public Task<DropboxFileEntity[]> Search(string query, int max_results)
        {
            return Task.Run(() =>
            {
                var entities = new DropboxFileEntity[] {
                    createTestDropboxFileEntity("dropboxtestfile1.txt"),
                    createTestDropboxFileEntity("dropboxtestfile2.txt"),
                    createTestDropboxFileEntity("dropboxtestfile3.txt"),
                    createTestDropboxFileEntity("dropboxtestfile4.txt"),
                    createTestDropboxFileEntity("dropboxtestfile5.txt"),
                    createTestDropboxFileEntity("dropboxtestfile6.txt")
                };

                return entities.Take(max_results).ToArray();
            });
        }
    }
}
