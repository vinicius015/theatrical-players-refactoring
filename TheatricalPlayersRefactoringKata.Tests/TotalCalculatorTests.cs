using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class TotalCalculatorTests
    {
        [Theory]
        [InlineData(0, "$0.00")]
        [InlineData(1, "$0.01")]
        [InlineData(100, "$1.00")]
        [InlineData(12345, "$123.45")]
        [InlineData(1000000, "$10,000.00")]
        public void FormattedAmount_FormatsCorrectly(int amount, string expected)
        {
            var calc = new TotalCalculator(amount);
            var result = calc.FormattedAmount(new CultureInfo("en-US"));
            Assert.Equal(expected, result);
        }
    }
}