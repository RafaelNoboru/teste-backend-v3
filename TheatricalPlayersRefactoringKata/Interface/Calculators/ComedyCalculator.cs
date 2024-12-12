using System;
using TheatricalPlayersRefactoringKata.Interface;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Calculators
{
    public class ComedyCalculator : IGenreCalculator
    {
        public decimal CalculateAmount(Play play, Performance performance)
        {
            decimal baseAmount = Math.Clamp(play.Lines / 10, 100, 400);
            baseAmount += 3 * performance.Audience;
            if (performance.Audience > 20)
            {
                baseAmount += 100 + (performance.Audience - 20) * 5;
            }
            return baseAmount;
        }

        public int CalculateCredits(Play play, Performance performance)
        {
            int credits = performance.Audience > 30 ? performance.Audience - 30 : 0;
            credits += (int)Math.Floor(performance.Audience / 5.0);
            return credits;
        }
    }
}
