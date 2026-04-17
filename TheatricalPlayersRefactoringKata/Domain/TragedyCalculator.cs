using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Domain
{
    public class TragedyCalculator : PlayCalculator
    {
        public TragedyCalculator(Performance performance, Play play) : base(performance, play) { }

        public override int Amount()
        {
            var result = 40000;
            if (Performance.Audience > 30)
                result += 1000 * (Performance.Audience - 30);
            return result;
        }
    }
}