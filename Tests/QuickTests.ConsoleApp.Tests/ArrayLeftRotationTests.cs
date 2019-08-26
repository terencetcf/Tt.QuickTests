using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class ArrayLeftRotationTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(int[] a, int d, int[] expectedResult)
        {
            var result = a.Skip(d).Concat(a.Take(d)).ToArray();

            result.Should().BeEquivalentTo(expectedResult);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                new int[] { 1, 2, 3, 4, 5 },
                4,
                new int[] { 5, 1, 2, 3, 4 },
            };
            yield return new object[] {
                new int[] { 41, 73, 89, 7, 10, 1, 59, 58, 84, 77, 77, 97, 58, 1, 86, 58, 26, 10, 86, 51 },
                10,
                new int[] { 77, 97, 58, 1, 86, 58, 26, 10, 86, 51, 41, 73, 89, 7, 10, 1, 59, 58, 84, 77 },
            };
        }
    }
}
