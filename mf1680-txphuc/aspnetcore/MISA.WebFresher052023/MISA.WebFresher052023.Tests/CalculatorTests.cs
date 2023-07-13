using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WebFresher052023.Demo;
using NUnit.Framework;

namespace MISA.WebFresher052023.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        //[Test]
        //public void Add_ValidInput_ValidResult()
        //{
        //    // Arrange (chuẩn bị dữ liệu)
        //    var x = 1;
        //    var y = 2;

        //    var expectedResult = 5;

        //    // Act (hành động)
        //    var actualResult = new Calculator().Add(x, y);


        //    // Assert
        //    Assert.That(actualResult, Is.EqualTo(expectedResult));
        //}

        [TestCase(1, 2, 3)]
        [TestCase(2, 3, 5)]
        [TestCase(int.MaxValue, 1, int.MaxValue + (long)1)]
        public void Add_ValidInput_ValidResult(int x, int y, long expectedResult)
        {
            // Arrange (chuẩn bị dữ liệu)


            // Act (hành động)
            var actualResult = new Calculator().Add(x, y);


            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(1, 2, -1)]
        [TestCase(2, 3, -1)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue - (long)int.MinValue)]
        public void Sub_ValidInput_ValidResult(int x, int y, long expectedResult)
        {
            // Act (hành động)
            var actualResult = new Calculator().Sub(x, y);


            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(1, 2, 2)]
        [TestCase(2, 3, 6)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)int.MinValue)]
        public void Mul_ValidInput_ValidResult(int x, int y, long expectedResult)
        {
            // Act (hành động)
            var actualResult = new Calculator().Mul(x, y);


            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Div_DevideByZero_ReturnsException()
        {
            // Arrange
            var x = 1;
            var y = 0;
            var expectedExceptionMessage = "Không chia được cho 0";

            // Act
            var exception = Assert.Throws<Exception>(() => new Calculator().Div(x, y));

            Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [TestCase(1, 2, 1 / (double)2)]
        [TestCase(2, 3, 2 / (double)3)]
        public void Div_ValidInput_ValidResult(int x, int y, double expectedResult)
        {
            // Act
            var actualResult = new Calculator().Div(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
