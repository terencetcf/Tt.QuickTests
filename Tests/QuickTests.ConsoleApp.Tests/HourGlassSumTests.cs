using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickTests.ConsoleApp.Tests
{
    public class HourGlassSumTests
    {
        [TestCase(1)]
        [TestCase(7)]
        public void IfArrayHasExceededRowLimit(int rows)
        {
            var testData = new int[rows][];

            Assert.Throws<InvalidOperationException>(() => HourGlassSum.GetHighestSum(testData));
        }

        [TestCase(1)]
        [TestCase(7)]
        public void IfArrayHasAnyColumnExceededColumnLimit(int cols)
        {
            var testData = new int[6][];
            for (var i = 0; i < testData.Length; i++)
            {
                testData[i] = Enumerable.Range(1, cols).ToArray();
            }

            Assert.Throws<InvalidOperationException>(() => HourGlassSum.GetHighestSum(testData));
        }

        [Test]
        public void IfAnyNumberGreaterThan9_ThrowException()
        {
            var testData = GetTestData();
            testData[1][1] = 10;

            Assert.Throws<InvalidOperationException>(() => HourGlassSum.GetHighestSum(testData));
        }

        [Test]
        public void IfAnyNumberLessThanNegative9_ThrowException()
        {
            var testData = GetTestData();
            testData[1][1] = -10;

            Assert.Throws<InvalidOperationException>(() => HourGlassSum.GetHighestSum(testData));
        }

        [TestCaseSource(nameof(TestData))]
        public void GetHighestSum_ShouldReturnExpectedResult(int[][] input, int expectedResult)
        {
            var result = HourGlassSum.GetHighestSum(input);

            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                 new int[][] {
                    new int[] {-9, -9, -9, 1, 1, 1 },
                    new int[] {0, -9, 0, 4, 3, 2 },
                    new int[] {-9, -9, -9, 1, 2, 3 },
                    new int[] {0, 0, 8, 6, 6, 0 },
                    new int[] {0, 0, 0, -2, 0, 0 },
                    new int[] {0, 0, 1, 2, 4, 0 }

                },
                28
            };
            yield return new object[] {
                new int[][] {
                    new int[] {1, 1, 1, 0, 0, 0},
                    new int[] {0, 1, 0, 0, 0, 0},
                    new int[] {1, 1, 1, 0, 0, 0},
                    new int[] {0, 0, 2, 4, 4, 0},
                    new int[] {0, 0, 0, 2, 0, 0},
                    new int[] {0, 0, 1, 2, 4, 0}
                },
                19
            };
        }


        private static int[][] GetTestData()
        {
            var testData = new int[][] {
                new int[] { 1, 2, 3, 4, 5, 6 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                new int[] { 1, 2, 3, 4, 5, 6 },
            };

            return testData;
        }
    }
}
