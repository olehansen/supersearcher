using SuperSearcher.Services.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperSearcher.Services
{
    public interface IStatisticService
    {
        void AddSearchTerm(string text);

        MySearchStats GetStats();
    }
}
