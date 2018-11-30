using NUnit.Framework;
using Shouldly;
using System;

namespace AssertionComparison
{

    [TestFixture]
    public class UsingShouldly : WhenCalculatingSummation
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int?[] addends, long expected)
        {
            AggregateCalculator.Sum(addends)
                .ShouldBe(expected);
        }

        [Test]
        public void TempVariable()
        {
            var sum = AggregateCalculator.Sum(1, -1);

            sum.ShouldBe(-1); // purposefully wrong
        }

        [Test]
        public void ArgumentNullException()
        {
            ((Action)RunNullSeries)
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void InnerException()
        {
            ((Action)RunSeriesWithNullValue)
                .ShouldThrow<CalculatorException>()
                .InnerException
                .ShouldBeOfType<InvalidOperationException>();
        }

        [Test]
        public void WrongOuterException()
        {
            ((Action)RunSeriesWithNullValue)
                .ShouldThrow<InvalidCastException>();
        }
    }

}