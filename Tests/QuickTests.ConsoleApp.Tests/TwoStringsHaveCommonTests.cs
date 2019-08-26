using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class TwoStringsHaveCommonTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(string s1, string s2, bool expectedResult)
        {
            var result = true;

            var s1Groups = s1.ToArray().GroupBy(s => s)
                .Select(s => new { s.Key, Total = s.Count() })
                .ToDictionary(g => g.Key, g => g.Total);
            var matches = s2.ToArray().GroupBy(s => s)
                .Select(s => new { s.Key, Total = s.Count() })
                .Where(w => s1Groups.ContainsKey(w.Key));

            if (matches.Count() < 1)
            {
                result = false;
            }

            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                "hello",
                "world",
                true
            };
            yield return new object[] {
                "hi",
                "world",
                false
            };
            yield return new object[] {
                "wouldyoulikefries",
                "abcabcabcabcabcabc",
                false
            };
            yield return new object[] {
                "hackerrankcommunity",
                "cdecdecdecde",
                true
            };
        }
    }
}
