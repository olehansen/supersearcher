using SuperSearcher.Infrastructure.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Infrastructure.Dropbox
{
    public abstract class DropboxBaseRepository
    {
        protected JsonAndBearerHttpClient client;

        public DropboxBaseRepository(JsonAndBearerHttpClient client)
        {
            this.client = client;
        }
    }
}
