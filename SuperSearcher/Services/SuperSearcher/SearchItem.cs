using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Services.SuperSearcher
{
    public class SearchItem
    {
        public string Name { get; set; }

        public SearchItemType Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} ", Name, Type);
        }
    }
}
