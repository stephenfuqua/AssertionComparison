using System;
using System.Linq;

namespace AssertionComparison
{
    public static class AggregateCalculator
    {
        public static long Sum(params int?[] addends)
        {
            if (addends == null)
            {
                throw new ArgumentNullException(nameof(addends));
            }

            if (addends.Length == 0)
            {
                throw new ArgumentException("values array contains no values", nameof(addends));
            }

            try
            {
                // ReSharper disable once PossibleInvalidOperationException
                return addends.Aggregate<int?, long>(0, (current, v) => current + v.Value);
            }
            catch (InvalidOperationException ex)
            {
                throw new CalculatorException("Creating an inner exception", ex);
            }
        }
    }

    public class CalculatorException  : Exception
    {
        public CalculatorException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
