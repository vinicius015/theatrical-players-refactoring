using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Models;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class ComedyCalculatorTests
    {
        [Theory]
        [InlineData(10, 33000)]
        [InlineData(20, 36000)]
        [InlineData(21, 46800)]
        [InlineData(25, 50000)]
        [InlineData(30, 54000)]
        public void Amount_CalculatesCorrectly(int audience, int expectedAmount)
        {
            var play = new Play("As You Like It", PlayType.Comedy);
            var perf = new Performance("as-like", audience);
            var calc = new ComedyCalculator(perf, play);

            Assert.Equal(expectedAmount, calc.Amount());
        }

        [Theory]
        [InlineData(10, 2)]
        [InlineData(20, 4)]
        [InlineData(25, 5)]
        [InlineData(30, 6)]
        [InlineData(31, 7)]
        public void VolumeCredits_CalculatesCorrectly(int audience, int expectedCredits)
        {
            var play = new Play("As You Like It", PlayType.Comedy);
            var perf = new Performance("as-like", audience);
            var calc = new ComedyCalculator(perf, play);

            Assert.Equal(expectedCredits, calc.VolumeCredits());
        }
    }
}