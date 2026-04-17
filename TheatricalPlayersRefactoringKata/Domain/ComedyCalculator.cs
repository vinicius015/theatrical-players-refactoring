using System;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Domain
{
    public class ComedyCalculator : PlayCalculator
    {
        public ComedyCalculator(Performance performance, Play play) : base(performance, play) { }

        public override int Amount()
        {
            var result = 30000;
            if (Performance.Audience > 20)
                result += 10000 + 500 * (Performance.Audience - 20);
            result += 300 * Performance.Audience;
            return result;
        }

        public override int VolumeCredits()
        {
            return base.VolumeCredits() + (int)Math.Floor((decimal)Performance.Audience / 5);
        }
    }
}