using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class MakeAnagramTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(string a, string b, long expectedResult)
        {
            var result = MakeAnagram.GetDeletedCharacters(a, b);

            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                "cde",
                "abc",
                4
            };
            yield return new object[] {
                "fcrxzwscanmligyxyvym",
                "jxwtrhvujlmrpdoqbisbwhmgpmeoke",
                30
            };
            yield return new object[] {
                "showman",
                "woman",
                2
            };
        }
    }
}
