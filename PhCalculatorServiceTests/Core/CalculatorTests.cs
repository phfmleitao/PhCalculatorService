using PhCalculatorService.Core;
using System;
using Xunit;

namespace PhCalculatorServiceTests.Core
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 3, 4)]
        [InlineData(300, 125, 425)]
        [InlineData(-16, 4, -12)]
        [InlineData(-8, -2, -10)]
        public void Sum_BasicSumOfTwoNumbers(int number1, int number2, int expected)
        {
            var calculator = new Calculator();
            var actual = calculator.Sum(number1, number2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(300, 125, 175)]
        [InlineData(-16, 4, -20)]
        [InlineData(-8, -2, -6)]
        public void Subtract_BasicSubtractionOfTwoNumbers(int number1, int number2, int expected)
        {
            var calculator = new Calculator();
            var actual = calculator.Subtract(number1, number2);

            Assert.Equal(expected, actual);
        }
    }
}
