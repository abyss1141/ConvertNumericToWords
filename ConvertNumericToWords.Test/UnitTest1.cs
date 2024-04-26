using ConvertNumericToWords.Models;
using ConvertNumericToWords.Service;
using Xunit;

namespace ConvertNumericToWords.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, "ZERO DOLLARS")]
        [InlineData(123, "ONE HUNDRED TWENTY- THREE DOLLARS")]
        [InlineData(1000, "ONE THOUSAND DOLLARS")]
        [InlineData(123124.13, "ONE HUNDRED TWENTY- THREE THOUSAND ONE HUNDRED TWENTY- FOUR DOLLARS AND TWELVE CENTS")]
        public void ConvertNumericToWord_ValidInput_ReturnsExpectedResult(double input, string expectedResult)
        {
            // Arrange
            ConverterService converterService = new ConverterService();

            // Act
            ServiceResponse<string> result = converterService.ConvertNumericToWord(input);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedResult, result.Data);
        }
    }
}