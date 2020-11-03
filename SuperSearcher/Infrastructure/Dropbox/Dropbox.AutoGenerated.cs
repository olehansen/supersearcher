using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Infrastructure.Dropbox
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class MatchType
    {
        [JsonProperty(".tag")]
        public string Tag { get; set; }
    }

    public class SharingInfo
    {
        public string modified_by { get; set; }
        public string parent_shared_folder_id { get; set; }
        public bool read_only { get; set; }
    }

    public class Metadata2
    {
        [JsonProperty(".tag")]
        public string Tag { get; set; }
        public DateTime client_modified { get; set; }
        public string content_hash { get; set; }
        public bool has_explicit_shared_members { get; set; }
        public string id { get; set; }
        public bool is_downloadable { get; set; }
        public string name { get; set; }
        public string path_display { get; set; }
        public string path_lower { get; set; }
        public List<object> property_groups { get; set; }
        public string rev { get; set; }
        public DateTime server_modified { get; set; }
        public SharingInfo sharing_info { get; set; }
        public int size { get; set; }
    }

    public class Metadata
    {
        [JsonProperty(".tag")]
        public string Tag { get; set; }
        public Metadata2 metadata { get; set; }
    }

    public class Match
    {
        public MatchType match_type { get; set; }
        public Metadata metadata { get; set; }
    }

    public class DropboxFileSearchObject
    {
        public bool has_more { get; set; }
        public List<Match> matches { get; set; }
    }


}
