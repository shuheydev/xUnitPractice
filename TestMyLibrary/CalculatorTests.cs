using System;
using Xunit;
using MyLibrary;

namespace TestMyLibrary.Tests
{
    public class CalculatorTests
    {

        [Theory]
        [InlineData(4, 3, 7)]
        [InlineData(21, 5.25, 26.25)]
        public void Add_SimpleValuesShouldCalculate(double x, double y, double result)
        {
            //Arrange
            double expected = result;

            //Act
            double actual = Calculator.Add(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
