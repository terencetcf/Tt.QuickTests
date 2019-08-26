using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class MaxArraySumTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(int[] arr, int expectedResult)
        {
            var inclusive = 0;
            var exclusive = 0;
            // 2, 1, 5, 8, 4

            for (var i = 0; i < arr.Length; i++)
            {
                // 0 2 2 7 10
                var temp = inclusive;

                // 2 2 7 10 11
                inclusive = Math.Max(inclusive, exclusive + arr[i]);
                
                // 0 2 2 7 10
                exclusive = temp;
            }

            var result = inclusive;

            //if (arr.Length == 1)
            //{
            //    result = arr.First();
            //    return;
            //}

            //if (arr.Length == 2)
            //{
            //    result = arr.Max(i => i);
            //}
            //for (int i = 2; i < arr.Length; i++)
            //{
            //    arr[i] = Math.Max(arr[i - 1], arr[i] + arr[i - 2]);
            //}

            Assert.AreEqual(expectedResult, result);
        }


        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                new int[] { -2, 1, 3, -4, 5 },
                8
            };
            yield return new object[] {
                new int[] { -3, 7, 4, 6, 5 },
                13
            };
            yield return new object[] {
                new int[] { 2, 1, 5, 8, 4 },
                11
            };
            yield return new object[] {
                new int[] { 3, 5, -7, 8, 10 },
                15
            };
        }
    }
}
