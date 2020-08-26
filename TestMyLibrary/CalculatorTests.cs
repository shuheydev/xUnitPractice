using System;
using Xunit;
using MyLibrary;

namespace TestMyLibrary.Tests
{
    public class CalculatorTests
    {
        
        [Fact]
        public void Add_SimpleValuesShouldCalculate()
        {
            //Arrange
            double expected = 5;

            //Act
            double actual = Calculator.Add(3, 2);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
