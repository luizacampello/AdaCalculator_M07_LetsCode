using System.Security.Cryptography;

namespace AdaCalculator.Tests
{
    public class CalculatorUnitTests
    {
        private readonly Calculator _calculator;

        public CalculatorUnitTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData("sum", 4.0, 2.0, 6.0)]
        [InlineData("sum", 5.0, 2.5, 7.5)]
        [InlineData("sum", 4.0, -1.0, 3.0)]
        [InlineData("sum", 4.0, -10.0, -6.0)]
        public void Calculator_Sum_ShouldReturnCorrectValue(string operation, double firstNumberr, double secondNumber, double result)
        {
            (string op, double result) results = _calculator.Calculate(operation, firstNumberr, secondNumber);

            Assert.Equal(results.result, result);
            Assert.Equal(results.op, operation);
        }

        [Theory]
        [InlineData("subtract", 4.0, 2.0, 2.0)]
        [InlineData("subtract", 5.0, 2.5, 2.5)]
        [InlineData("subtract", 4.0, -1.0, 5.0)]
        [InlineData("subtract", 4.0, -10.0, 14.0)]
        public void Calculator_Subtract_ShouldReturnCorrectValue(string operation, double firstNumberr, double secondNumber, double result)
        {
            (string op, double result) results = _calculator.Calculate(operation, firstNumberr, secondNumber);

            Assert.Equal(results.result, result);
            Assert.Equal(results.op, operation);
        }

        [Theory]
        [InlineData("divide", 4.0, 2.0, 2.0)]
        [InlineData("divide", 10.0, 20.0, 0.5)]
        public void Calculator_Divide_ShouldReturnCorrectValue(string operation, double dividend, double divisor, double result)
        {
            (string op, double result) results = _calculator.Calculate(operation, dividend, divisor);

            Assert.Equal(results.result, result);
            Assert.Equal(results.op, operation);
        }

        [Theory]
        [InlineData("multiply", 4.0, 2.0, 8.0)]
        [InlineData("multiply", 10.0, 2.0, 20.0)]
        public void Calculator_Multiply_ShouldReturnCorrectValue(string operation, double dividend, double divisor, double result)
        {
            (string op, double result) results = _calculator.Calculate(operation, dividend, divisor);

            Assert.Equal(results.result, result);
            Assert.Equal(results.op, operation);
        }

        [Theory]
        [InlineData("luiza")]
        public void Calculator_NotAvaiableOperation_ShouldThrowException(string operation)
        {

            Action result = () => _calculator.Calculate(operation, 1, 2);

            Assert.Throws<ArgumentException>(result);
        }
    }
}