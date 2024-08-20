using System.Collections.Generic;
using System.Globalization;
using System;
using TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    private readonly Dictionary<PlayType, IPlayCalculator> _calculators = new()
    {
        { PlayType.Tragedy, new TragedyCalculator() },
        { PlayType.Comedy, new ComedyCalculator() },
        { PlayType.Historical, new HistoricalCalculator() }
    };

    public string Print(Invoice invoice)
    {
        var totalAmount = 0;
        var volumeCredits = 0;
        var result = $"Statement for {invoice.Customer}\n";
        CultureInfo cultureInfo = new CultureInfo("en-US");

        foreach (var perf in invoice.Performances)
        {
            var calculator = _calculators[perf.Play.Type];
            var thisAmount = calculator.CalculateAmount(perf);
            volumeCredits += calculator.CalculateVolumeCredits(perf);

            result += string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", perf.Play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
            totalAmount += thisAmount;
        }

        result += string.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
        result += $"You earned {volumeCredits} credits\n";
        return result;
    }

    public global::ApprovalTests.Core.IApprovalApprover PrintXml(Invoice invoice)
    {
        throw new NotImplementedException();
    }
}
