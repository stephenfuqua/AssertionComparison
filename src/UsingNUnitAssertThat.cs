using NUnit.Framework;
using System;

namespace AssertionComparison
{

    [TestFixture]
    public class UsingNUnitAssertThat : WhenCalculatingSummation
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int?[] addends, long expected)
        {
            Assert.That(AggregateCalculator.Sum(addends), Is.EqualTo(expected));
        }


        [Test]
        public void TempVariable()
        {
            var sum = AggregateCalculator.Sum(1, -1);

            Assert.That(sum, Is.EqualTo(-1)); // purposefully wrong
        }

        [Test]
        public void ArgumentNullException()
        {
            //Assert.That(RunNullSeries, Throws.ArgumentNullException);
            Assert.That(RunNullSeries, Throws.InstanceOf<ArgumentNullException>());

        }


        [Test]
        public void InnerException()
        {
            Assert.That(RunSeriesWithNullValue, 
                    Throws.TypeOf<CalculatorException>()
                        .With.InnerException.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void WrongOuterException()
        {
            Assert.That(RunSeriesWithNullValue, Throws.TypeOf<InvalidCastException>());
        }
    }

}