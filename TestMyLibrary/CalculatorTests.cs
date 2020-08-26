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
        [InlineData(double.MaxValue, 5, double.MaxValue)]//edge case
        public void Add_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            //Arrange

            //Act
            double actual = Calculator.Add(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8,4,4)]
        public void Divide_SimpleValuesShouldCalculate(double x,double y,double expected)
        {
            //Arrange
            //Act
            double actual = Calculator.Divide(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
