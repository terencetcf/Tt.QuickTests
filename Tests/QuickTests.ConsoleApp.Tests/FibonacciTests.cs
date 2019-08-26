using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class FibonacciTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(int n, int expectedResult)
        {
            var result = GetFibonacci(n);

            Assert.AreEqual(expectedResult, result);
        }

        public static int GetFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                3,
                2
            };
            yield return new object[] {
                4,
                3
            };
            yield return new object[] {
                5,
                5
            };
            yield return new object[] {
                6,
                8
            };
        }
    }
}
