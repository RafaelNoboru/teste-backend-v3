using System.Collections.Generic;
using System.Text;
using TheatricalPlayersRefactoringKata.Interface;
using TheatricalPlayersRefactoringKata.Repository;

namespace TheatricalPlayersRefactoringKata.Models
{
    public class TextFormatter : IStatementFormatter
    {
        public string Format(Invoice invoice, Dictionary<string, Play> plays)
        {
            var result = new StringBuilder();
            result.AppendLine($"Statement for {invoice.Customer}");
            decimal totalAmount = 0;
            int totalCredits = 0;

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayId];
                var calculator = GenreCalculatorFactory.GetCalculator(play.Type);

                decimal thisAmount = calculator.CalculateAmount(play, perf);
                int thisCredits = calculator.CalculateCredits(play, perf);

                result.AppendLine($"  {play.Name}: {thisAmount.ToString("C", new System.Globalization.CultureInfo("en-US"))} ({perf.Audience} seats)");
                totalAmount += thisAmount;
                totalCredits += thisCredits;
            }

            result.AppendLine($"Amount owed is {totalAmount.ToString("C", new System.Globalization.CultureInfo("en-US"))}");
            result.AppendLine($"You earned {totalCredits} credits");
            return result.ToString();
        }
    }
}
