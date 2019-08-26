using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class RepeatedStringTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void InputStringIsInvalid_ThrowException(string input)
        {
            Assert.Throws<InvalidOperationException>(() => RepeatedString.GetTotal(input, 1));
        }

        [Test]
        public void InputStringIsGreaterThan100_ThrowException()
        {
            var input = new string(Enumerable.Repeat('a', 101)
                            .Select(s => s).ToArray());

            Assert.Throws<InvalidOperationException>(() => RepeatedString.GetTotal(input, 1));
        }

        [Test]
        public void InputNumberIsLessthan1_ThrowException()
        {
            var input = 0;

            Assert.Throws<InvalidOperationException>(() => RepeatedString.GetTotal("a", input));
        }

        [Test]
        public void InputNumberIsGreaterthan10PowerOf12_ThrowException()
        {
            long input = (long)Math.Pow(10, 12) + 1;

            Assert.Throws<InvalidOperationException>(() => RepeatedString.GetTotal("a", input));
        }


        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(string input, long repeat, long expectedResult)
        {
            var result = RepeatedString.GetTotal(input, repeat);

            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                "aba",
                10,
                7
            };
            yield return new object[] {
                "a",
                1000000000000,
                1000000000000
            };
        }
    }
}
