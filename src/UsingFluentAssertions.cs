using FluentAssertions;
using NUnit.Framework;
using System;

namespace AssertionComparison
{

    [TestFixture]
    public class UsingFluentAssertions : WhenCalculatingSummation
    {
        [TestCaseSource(nameof(TestCases)), Order(1)]
        public void Test(int?[] addends, long expected)
        {
            AggregateCalculator.Sum(addends)
                .Should()
                .Be(expected);
        }

        [Test]
        public void TempVariable()
        {
            var sum = AggregateCalculator.Sum(1, -1);

            sum.Should()
               .Be(-1); // purposefully wrong
        }

        [Test]
        public void ArgumentNullException()
        {
            ((Action)RunNullSeries)
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Test]
        public void InnerException()
        {
            ((Action)RunSeriesWithNullValue)
                .Should()
                .Throw<CalculatorException>()
                .WithInnerException<InvalidOperationException>();
        }

        [Test]
        public void WrongOuterException()
        {
            ((Action)RunSeriesWithNullValue)
                .Should()
                .Throw<InvalidCastException>();
        }
    }

}