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

        // Bài tập
        /// <summary>
        /// Trường hợp đầu vào là chuỗi rỗng
        /// </summary>
        /// CreatedBy: txphuc (13/07/2023)
        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            // Arrange
            var str = "";
            var expectedResult = 0;

            // Act
            var actualResult = new Calculator().Add(str);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Trường hợp đầu vào là chuỗi có một hoặc nhiều số KHÔNG âm
        /// phân tách nhau bởi dấu `,` có dạng: "1" hoặc "1,2,3" hoặc "1, 2, 3"
        /// </summary>
        /// <param name="str">Giá trị đầu vào</param>
        /// <param name="expectedResult">Kết quả mong đợi</param>
        /// CreatedBy: txphuc (13/07/2023)
        [TestCase("1", 1)]
        [TestCase("20", 20)]
        [TestCase("1,2,3", 6)]
        [TestCase("1, 2, 3", 6)]
        public void Add_MultipleNumbersString_ReturnTotal(string str, int expectedResult)
        {
            // Act
            var actualResult = new Calculator().Add(str);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Trường hợp đầu vào là chuỗi có một hoặc nhiều số âm
        /// phân tách nhau bởi dấu `,` có dạng: "-1" hoặc "1,-2,-3" hoặc "1, -2, -3"
        /// </summary>
        /// <param name="str"></param>
        /// CreatedBy: txphuc (13/07/2023)
        [TestCase("-1", "Không chấp nhận toán tử âm: -1")]
        [TestCase("1,-2,-3", "Không chấp nhận toán tử âm: -2, -3")]
        [TestCase("1, -2, -3", "Không chấp nhận toán tử âm: -2, -3")]
        public void Add_NegativeNumberString_ReturnException(string str, string expectedExceptionMessage)
        {
            // Act
            var exception = Assert.Throws<Exception>(() => new Calculator().Add(str));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
        }

        /// <summary>
        /// Trường hợp chuỗi không hợp lệ
        /// </summary>
        /// <param name="str"></param>
        /// CreatedBy: txphuc (13/07/2023)
        [TestCase("Đây là chuỗi không hợp lệ")]
        public void Add_InvalidInput_ReturnException(string str)
        {
            // Arrange
            var expectedExceptionMessage = "Chuỗi không hợp lệ";

            // Act
            var exception = Assert.Throws<Exception>(() => new Calculator().Add(str));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
