using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class MakeAnaalternatingCharactersTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(string input, int expectedResult)
        {
            int result = 0;
            var list = input.ToArray().ToList();
            for (var i = 0; i < list.Count() - 1; i++)
            {
                if (list[i] == list[i+1])
                {
                    list.RemoveAt(i);
                    result++;
                    i--;
                }
            }

            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                "AAAA",
                3
            };
            yield return new object[] {
                "BBBBB",
                4
            };
            yield return new object[] {
                "ABABABAB",
                0
            };
            yield return new object[] {
                "BABABA",
                0
            };
            yield return new object[] {
                "AAABBB",
                4
            };

        }
    }
}
