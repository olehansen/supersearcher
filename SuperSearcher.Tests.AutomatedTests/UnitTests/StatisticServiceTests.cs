using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSearcher.Infrastructure.Dropbox;
using SuperSearcher.Services;
using SuperSearcher.Tests.AutomatedTests.TestDoubles;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.Tests.AutomatedTests.UnitTests
{
    [TestClass]
    public class StatisticServiceTests
    {
        [TestMethod]
        public void AddSearchTermAndGetStats()
        {
            var subSearchTermRepository = new SubSearchTermRepository();
            var statisticService = new StatisticService(subSearchTermRepository);

            var searchTerms = new string[]
            {
                "spy1",
                "unknown2",
                "flavor3",
                "supreme4",
                "imp5ress",
                "nut6ty",
                "sw7im",
                "conscious",
                "example",
                "insidious",
                "puffy",
                "decisive",
                "control",
                "raise",
                "outstanding",
                "cruel",
                "abrasive",
                "mountain",
                "flame",
                "remember",
                "story",
                "angry",
                "peace",
                "hollow",
                "rotten",
                "mountainous",
                "pipe",
                "truck",
                "freezing",
                "beginner",
                "offbeat",
                "scrub",
                "arch",
                "crazy",
                "awesome",
                "bait",
                "long",
                "brake",
                "clip",
                "abundant",
                "interfere",
                "party",
                "dangerous",
                "aromatic",
                "clos&ed",
                "mea&t",
                "sil&ent",
                "jo%g",
                "wr¤athful",
                "i#ce"
            };

            foreach (var searchTerm in searchTerms)
            {
                statisticService.AddSearchTerm(searchTerm);
            }

            var mySearchStats = statisticService.GetStats();

            Assert.AreEqual(7, mySearchStats.CountContainingNumbers);
            Assert.AreEqual(6, mySearchStats.CountContainingSymbols);
            Assert.AreEqual(searchTerms.Length, mySearchStats.SearchCount);
            Assert.AreEqual(searchTerms.Average(x => x.Length), mySearchStats.AverageLength);
        }
    }
}