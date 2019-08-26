using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class GameOfThronesPalindromicTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(string s, bool expectedResult)
        {
            var result = true;

            var groups = s.ToArray().GroupBy(c => c)
                .Select(c => new { c.Key, Total = c.Count() });
            //.ToDictionary(g => g.Key, g => g.Total);

            var alreadyHasException = false;
            foreach (var group in groups)
            {
                if (group.Total % 2 != 0)
                {
                    if (alreadyHasException)
                    {
                        result = false;
                        break;
                    }

                    alreadyHasException = true;
                } 
            }
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                "aaabbbb",
                true,
            };
            yield return new object[] {
                "cdefghmnopqrstuvw",
                false,
            };
            yield return new object[] {
                "cdcdcdcdeeeef",
                true,
            };
        }
    }
}
