using System;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Domain
{
    public static class PlayCalculatorFactory
    {
        public static PlayCalculator Create(Performance performance, Play play)
        {
            return play.Type switch
            {
                PlayType.Tragedy => new TragedyCalculator(performance, play),
                PlayType.Comedy => new ComedyCalculator(performance, play),
                _ => throw new ArgumentException($"Unknown play type: {play.Type}")
            };
        }
    }
}