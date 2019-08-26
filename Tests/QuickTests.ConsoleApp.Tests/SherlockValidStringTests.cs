using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class SherlockValidStringTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(string s, bool expectedResult)
        {
            var list = s.ToArray().ToList();
            var result = MatchingGroups(list);

            if (!result)
            {
                var groups = list.GroupBy(l => l);
                var largestGroup = groups.OrderByDescending(l => l.Count()).First();
                var firstIndexOf = list.IndexOf(largestGroup.Key);
                list.RemoveAt(firstIndexOf);
                result = MatchingGroups(list);

                if (!result)
                {
                    list = s.ToArray().ToList();
                    groups = list.GroupBy(l => l);
                    var smallestGroup = groups.OrderBy(l => l.Count()).First();
                    firstIndexOf = list.IndexOf(smallestGroup.Key);
                    list.RemoveAt(firstIndexOf);
                    result = MatchingGroups(list);
                }
            }

            Assert.AreEqual(expectedResult, result);
        }

        private static bool MatchingGroups(List<char> list)
        {
            var groups = list.GroupBy(l => l);
            var largestGroupCount = groups.Max(l => l.Count());
            var smallestGroupCount = groups.Min(l => l.Count());

            return largestGroupCount == smallestGroupCount;
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                "abcc",
                true
            };
            yield return new object[] {
                "aabbc",
                true
            };
            
            yield return new object[] {
                "aaaabb",
                false
            };
            yield return new object[] {
                "aabbcd",
                false
            };
            yield return new object[] {
                "aabbccddeefghi",
                false
            };
            yield return new object[] {
                "abcabc",
                true
            };
            yield return new object[] {
                "abcdefghhgfedecba",
                true
            };


        }
    }
}
