using System.Collections.Generic;

namespace AssertionComparison
{
    public abstract class WhenCalculatingSummation
    {
        protected static readonly object[] TestCases =
        {
            new object[] { new int?[] { 1, 2, 3, 4}, 10 },
            new object[] { new int?[] { 1, -1, 2, 0 }, 2},
            new object[] { new int?[] { int.MaxValue, int.MaxValue}, (long)2*int.MaxValue},
            new object[] { GenerateSeries(100000), 4999950000 },
            // These are all wrong on purpose
            new object[] { new int?[] { int.MaxValue, int.MinValue}, 0},
            new object[] { GenerateSeries(100001), 4999950001 },
            new object[] { GenerateSeries(100002), 4999950001 },
            new object[] { GenerateSeries(100003), 4999950001 },
            new object[] { GenerateSeries(100004), 4999950001 },
            new object[] { GenerateSeries(100005), 4999950001 },
            new object[] { GenerateSeries(100006), 4999950001 },
            new object[] { GenerateSeries(100007), 4999950001 },
            new object[] { GenerateSeries(100008), 4999950001 },
            new object[] { GenerateSeries(100009), 4999950001 }
        };

        private static int?[] GenerateSeries(int length)
        {
            var series = new List<int?>();
            for (var i = 0; i < length; i++)
            {
                series.Add(i);
            }
            return series.ToArray();
        }

        protected static void RunNullSeries()
        {
            AggregateCalculator.Sum(null);
        }

        protected static void RunSeriesWithNullValue()
        {
            AggregateCalculator.Sum(1, 2, null);
        }
    }
}