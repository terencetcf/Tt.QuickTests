using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class StringConstructionCopyCostTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(string s, int expectedResult)
        {
            var result = 0;

            var groups = s.ToArray().GroupBy(c => c)
                .Select(c => new { c.Key, Total = c.Count() });

            result = groups.Count();

            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                "abcabc",
                3,
            };
            yield return new object[] {
                "abcd",
                4,
            };
            yield return new object[] {
                "abab",
                2,
            };
        }
    }
}
