using NUnit.Framework;
using Should;
using System;

namespace AssertionComparison
{

    [TestFixture]
    public class UsingShould : WhenCalculatingSummation
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int?[] addends, long expected)
        {
            AggregateCalculator.Sum(addends)
                .ShouldEqual(expected);
        }


        [Test]
        public void TempVariable()
        {
            var sum = AggregateCalculator.Sum(1, -1);

            sum.ShouldEqual(-1); // purposefully wrong
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
            // No native way to test inner exception type

            try
            {
                RunSeriesWithNullValue();
            }
            catch (CalculatorException ex)
            {
                ex.InnerException.ShouldBeType<InvalidOperationException>();
            }
        }

        [Test]
        public void WrongOuterException()
        {
            ((Action)RunSeriesWithNullValue)
                .ShouldThrow<InvalidCastException>();
        }
    }

}