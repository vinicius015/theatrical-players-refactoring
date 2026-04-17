using System.Globalization;

namespace TheatricalPlayersRefactoringKata.Domain
{
    public class TotalCalculator
    {
        private readonly int _amount;
        public TotalCalculator(int amount) => _amount = amount;
        public string FormattedAmount(CultureInfo cultureInfo)
            => (_amount / 100m).ToString("C", cultureInfo);
    }
}