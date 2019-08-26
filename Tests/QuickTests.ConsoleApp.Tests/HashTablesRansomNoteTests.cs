using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class HashTablesRansomNoteTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(string[] magazine, string[] note, bool expectedResult)
        {
            var result = true;

            var magazineDict = magazine.GroupBy(s => s)
                .Select(s => new { s.Key, Total = s.Count() })
                .ToDictionary(g => g.Key, g => g.Total);
            var noteGroups = note.GroupBy(s => s)
                .Select(s => new { s.Key, Total = s.Count() })
                .Where(w => !magazineDict.ContainsKey(w.Key)
                || (magazineDict.ContainsKey(w.Key) && w.Total > magazineDict[w.Key]));

            if (noteGroups.Count() > 0)
            {
                result = false;
            }

            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                new [] { "give", "me", "one", "grand", "today", "night" },
                new [] { "give", "one", "grand", "today" },
                true
            };
            yield return new object[] {
                new [] { "two", "times", "three", "is", "not", "four" },
                new [] { "two", "times", "two", "is", "four" },
                false
            };
            yield return new object[] {
                new [] { "ive", "got", "a", "lovely", "bunch", "of", "coconuts" },
                new [] { "ive", "got", "some", "coconuts" },
                false
            };
        }
    }
}
