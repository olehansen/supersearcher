using SuperSearcher.Infrastructure.Web;
using SuperSearcher.Infrastructure.Dropbox.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Infrastructure.Dropbox
{
    public class DropboxRepositoryFactory
    {
        private JsonAndBearerHttpClient httpClient;

        public DropboxRepositoryFactory(string accessToken)
        {
            httpClient = new JsonAndBearerHttpClient("https://api.dropboxapi.com/2/", accessToken);
        }

        public DropboxFileRepository CreateDropboxFilesRepository()
        {
            return new DropboxFileRepository(httpClient);
        }
    }
}
