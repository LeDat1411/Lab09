using Xunit;
using CalculatorType = Calculator.BasicMath.BasicMaths;

namespace BasicMathTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(0, 0, 0)]
        [InlineData(int.MaxValue, 1, 2147483648d)]
        public void Add_MultipleValues_ReturnsCorrectSum(
            double a,
            double b,
            double expected)
        {
            var calculator = new CalculatorType();

            double result = calculator.Add(a, b);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-5, -3, -2)]
        [InlineData(0, 0, 0)]
        [InlineData(double.MinValue, 1, double.MinValue - 1)]
        public void Subtract_MultipleValues_ReturnsCorrectDifference(
            double a,
            double b,
            double expected)
        {
            var calculator = new CalculatorType();

            double result = calculator.Subtract(a, b);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, -3, 6)]
        [InlineData(0, 5, 0)]
        [InlineData(int.MaxValue, 1, int.MaxValue)]
        public void Multiply_MultipleValues_ReturnsCorrectProduct(
            double a,
            double b,
            double expected)
        {
            var calculator = new CalculatorType();

            double  result = calculator.Multiply(a, b);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(-6, -3, 2)]
        [InlineData(0, 1, 0)]
        [InlineData(int.MaxValue, 1, int.MaxValue)]
        public void Divide_MultipleValues_ReturnsCorrectQuotient(
            double a,
            double b,
            double expected)
        {
            var calculator = new CalculatorType();

            double result = calculator.Divide(a, b);

            Assert.Equal(expected, result);
        }
    }
}
