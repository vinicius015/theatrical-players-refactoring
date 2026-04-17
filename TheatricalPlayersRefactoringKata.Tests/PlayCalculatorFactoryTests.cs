using System;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Models;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class PlayCalculatorFactoryTests
    {
        [Fact]
        public void Create_WithTragedyType_ReturnsTragedyCalculator()
        {
            var play = new Play("Hamlet", PlayType.Tragedy);
            var perf = new Performance("hamlet", 10);

            var calc = PlayCalculatorFactory.Create(perf, play);

            Assert.IsType<TragedyCalculator>(calc);
        }

        [Fact]
        public void Create_WithComedyType_ReturnsComedyCalculator()
        {
            var play = new Play("As You Like It", PlayType.Comedy);
            var perf = new Performance("as-like", 10);

            var calc = PlayCalculatorFactory.Create(perf, play);

            Assert.IsType<ComedyCalculator>(calc);
        }

        [Fact]
        public void Create_WithUnknownType_ThrowsArgumentException()
        {
            var play = new Play("Unknown", (PlayType)999);
            var perf = new Performance("unknown", 10);

            var ex = Assert.Throws<ArgumentException>(() => PlayCalculatorFactory.Create(perf, play));
            Assert.Equal("Unknown play type: 999", ex.Message);
        }
    }
}