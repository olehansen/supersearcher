using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.Services.Statistics
{
    public class MySearchStats
    {
        // (e.g. length/count, distribution of letters/numbers/symbols, etc.
        public int CountContainingNumbers { get; internal set; }
        public double AverageLength { get; internal set; }
        public int CountContainingSymbols { get; internal set; }
        public int SearchCount { get; internal set; }
    }
}
