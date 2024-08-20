using System;
using TheatricalPlayersRefactoringKata;

public class TragedyCalculator : IPlayCalculator
{
    public int CalculateAmount(Performance performance)
    {
        var thisAmount = performance.Play.Lines * 10;
        if (performance.Audience > 30)
        {
            thisAmount += 1000 * (performance.Audience - 30);
        }
        return thisAmount;
    }

    public int CalculateVolumeCredits(Performance performance)
    {
        return Math.Max(performance.Audience - 30, 0);
    }
}

public class ComedyCalculator : IPlayCalculator
{
    public int CalculateAmount(Performance performance)
    {
        var thisAmount = performance.Play.Lines * 10;
        if (performance.Audience > 20)
        {
            thisAmount += 10000 + 500 * (performance.Audience - 20);
        }
        thisAmount += 300 * performance.Audience;
        return thisAmount;
    }

    public int CalculateVolumeCredits(Performance performance)
    {
        return Math.Max(performance.Audience - 30, 0) + (int)Math.Floor((decimal)performance.Audience / 5);
    }
}

public class HistoricalCalculator : IPlayCalculator
{
    private readonly TragedyCalculator _tragedyCalculator = new();
    private readonly ComedyCalculator _comedyCalculator = new();

    public int CalculateAmount(Performance performance)
    {
        return _tragedyCalculator.CalculateAmount(performance) + _comedyCalculator.CalculateAmount(performance);
    }

    public int CalculateVolumeCredits(Performance performance)
    {
        return _tragedyCalculator.CalculateVolumeCredits(performance) + _comedyCalculator.CalculateVolumeCredits(performance);
    }
}
