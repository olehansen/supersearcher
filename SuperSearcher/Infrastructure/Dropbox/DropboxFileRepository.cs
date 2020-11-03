using SuperSearcher.Infrastructure.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuperSearcher.Repositories;
using SuperSearcher.DomainEntities.Dropbox;

namespace SuperSearcher.Infrastructure.Dropbox.repositories
{
    public class DropboxFileRepository : DropboxBaseRepository, IDropboxFileRepository
    {
        public DropboxFileRepository(JsonAndBearerHttpClient client) : base(client)
        {
        }

        public async Task<DropboxFileEntity[]> Search(string query, int max_results)
        {
            // curl - X POST https://api.dropboxapi.com/2/files/search_v2 \
            //--header "Authorization: Bearer " \
            //--header "Content-Type: application/json" \
            //--data "{\"query\": \"cat\",\"options\": {\"path\": \"/Folder\",\"max_results\": 20,\"file_status\": \"active\",\"filename_only\": false},\"match_field_options\": {\"include_highlights\": false}}"

            var response = await client.PostAsync<DropboxFileSearchObject>(
                "files/search_v2",
                "{\"query\": \"" + query + "\",\"options\": {\"max_results\": " + max_results + ",\"file_status\": \"active\",\"filename_only\": false},\"match_field_options\": {\"include_highlights\": false}}"
                );

            var fileEntities = new List<DropboxFileEntity>();

            foreach (var match in response.matches)
            {
                fileEntities.Add(new DropboxFileEntity()
                {
                    Name = match.metadata.metadata.name
                });
            }

            return fileEntities.ToArray();
        }
    }
}