using System.Collections.Generic;
using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            var totalCalculator = new TotalCalculator(0);
            var totalAmount = 0;
            var volumeCredits = 0;
            var result = $"Statement for {invoice.Customer}\n";
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayID];
                var calculator = PlayCalculatorFactory.Create(perf, play);
                var thisAmount = calculator.Amount();
                volumeCredits += calculator.VolumeCredits();

                totalCalculator = new TotalCalculator(thisAmount);
                result += $"  {play.Name}: {totalCalculator.FormattedAmount(cultureInfo)} ({perf.Audience} seats)\n";
                totalAmount += thisAmount;
            }

            totalCalculator = new TotalCalculator(totalAmount);
            result += $"Amount owed is {totalCalculator.FormattedAmount(cultureInfo)}\n";
            result += $"You earned {volumeCredits} credits\n";

            return result;
        }
    }
}
