using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Domain
{
    public class TragedyCalculator : PlayCalculator
    {
        private const int BaseAmount = 40000;
        private const int AudienceThreshold = 30;
        private const int ExtraPerAudience = 1000;

        public TragedyCalculator(Performance performance, Play play) : base(performance, play) { }

        public override int Amount()
        {
            var result = BaseAmount;
            if (Performance.Audience > AudienceThreshold)
                result += ExtraPerAudience * (Performance.Audience - AudienceThreshold);
            return result;
        }
    }
}