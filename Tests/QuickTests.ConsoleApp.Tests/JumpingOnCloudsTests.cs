using NUnit.Framework;
using QuickTests.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class JumpingOnCloudsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IfTotalCloudLessThan2_ThrowException()
        {
            var input = new[] { 0 };

            Assert.Throws<InvalidOperationException>(() => JumpingOnClouds.GetTotalSteps(input));
        }

        [Test]
        public void IfTotalCloudLessGreaterThan100_ThrowException()
        {
            var input = Enumerable.Range(1, 101).ToArray();

            Assert.Throws<InvalidOperationException>(() => JumpingOnClouds.GetTotalSteps(input));
        }

        [Test]
        public void IfContainsAnyNumbersThatAreNotOneOrZero_ThrowException()
        {
            var input = new[] { 0, 1, -1, 2};

            Assert.Throws<InvalidOperationException>(() => JumpingOnClouds.GetTotalSteps(input));
        }

        [TestCaseSource(nameof(TestData))]
        public void jumpingOnClouds_ShouldReturnExpectedResult(int[] input, int expectedResult)
        {
            var result = JumpingOnClouds.GetTotalSteps(input);

            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                new int[] { 0, 0, 1, 0, 0, 1, 0 },
                4
            };
            yield return new object[] {
                new int[] { 0, 0, 0, 0, 1, 0 },
                3
            };
        }
    }
}