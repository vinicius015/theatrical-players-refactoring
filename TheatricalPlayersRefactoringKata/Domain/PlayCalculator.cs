using System;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Domain
{
    public abstract class PlayCalculator
    {
        protected Performance Performance { get; }
        protected Play Play { get; }

        protected PlayCalculator(Performance performance, Play play)
        {
            Performance = performance;
            Play = play;
        }

        public abstract int Amount();
        public virtual int VolumeCredits()
        {
            return Math.Max(Performance.Audience - 30, 0);
        }
    }
}