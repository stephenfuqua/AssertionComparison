using NUnit.Framework;
using System;

namespace AssertionComparison
{


    [TestFixture]
    public class UsingNUnitAssert : WhenCalculatingSummation
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int?[] addends, long expected)
        {
            Assert.AreEqual(expected, AggregateCalculator.Sum(addends));
        }


        [Test]
        public void TempVariable()
        {
            var sum = AggregateCalculator.Sum(1, -1);

            Assert.AreEqual(sum, -1); // purposefully wrong
        }

        [Test]
        public void ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(RunNullSeries);
        }


        [Test]
        public void InnerException()
        {
            try
            {
                RunSeriesWithNullValue();
            }
            catch (CalculatorException outer)
            {
                Assert.IsInstanceOf<Exception>(outer);
            }
        }

        [Test]
        public void WrongOuterException()
        {
            Assert.Throws<InvalidCastException>(RunSeriesWithNullValue);
        }
    }

}