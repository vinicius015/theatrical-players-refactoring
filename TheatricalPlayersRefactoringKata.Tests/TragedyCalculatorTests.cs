using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Models;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class TragedyCalculatorTests
    {
        [Theory]
        [InlineData(20, 40000)]
        [InlineData(30, 40000)]
        [InlineData(31, 41000)]
        [InlineData(40, 50000)]
        public void Amount_CalculatesCorrectly(int audience, int expectedAmount)
        {
            var play = new Play("Hamlet", PlayType.Tragedy);
            var perf = new Performance("hamlet", audience);
            var calc = new TragedyCalculator(perf, play);

            Assert.Equal(expectedAmount, calc.Amount());
        }

        [Theory]
        [InlineData(20, 0)]
        [InlineData(30, 0)]
        [InlineData(31, 1)]
        [InlineData(40, 10)]
        public void VolumeCredits_CalculatesCorrectly(int audience, int expectedCredits)
        {
            var play = new Play("Hamlet", PlayType.Tragedy);
            var perf = new Performance("hamlet", audience);
            var calc = new TragedyCalculator(perf, play);

            Assert.Equal(expectedCredits, calc.VolumeCredits());
        }
    }
}