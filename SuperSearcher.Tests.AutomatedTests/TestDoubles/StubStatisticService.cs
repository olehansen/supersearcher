using SuperSearcher.Services;
using SuperSearcher.Services.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Tests.AutomatedTests.TestDoubles
{
    public class StubStatisticService : IStatisticService
    {
        private int searchTermCounter = 0;

        public void AddSearchTerm(string text)
        {
            searchTermCounter++;
        }

        public MySearchStats GetStats()
        {
            throw new NotImplementedException();
        }

        public int GetSearchTermCount()
        {
            return searchTermCounter;
        }
    }
}
