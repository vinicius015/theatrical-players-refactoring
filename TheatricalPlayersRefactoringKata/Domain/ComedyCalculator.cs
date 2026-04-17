using System;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Domain
{
    public class ComedyCalculator : PlayCalculator
    {
        private const int BaseAmount = 30000;
        private const int AudienceThreshold = 20;
        private const int BonusAmount = 10000;
        private const int ExtraPerAudience = 500;
        private const int PerAudience = 300;
        private const int VolumeCreditDivisor = 5;

        public ComedyCalculator(Performance performance, Play play) : base(performance, play) { }

        public override int Amount()
        {
            var result = BaseAmount;
            if (Performance.Audience > AudienceThreshold)
                result += BonusAmount + ExtraPerAudience * (Performance.Audience - AudienceThreshold);
            result += PerAudience * Performance.Audience;
            return result;
        }

        public override int VolumeCredits()
        {
            return base.VolumeCredits() + (int)Math.Floor((decimal)Performance.Audience / VolumeCreditDivisor);
        }
    }
}