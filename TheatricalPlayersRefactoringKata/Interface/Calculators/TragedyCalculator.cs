using System;
using TheatricalPlayersRefactoringKata.Interface;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Calculators
{
    public class TragedyCalculator : IGenreCalculator
    {
        public decimal CalculateAmount(Play play, Performance performance)
        {
            decimal baseAmount = Math.Clamp(play.Lines / 10, 100, 400);
            if (performance.Audience > 30)
            {
                baseAmount += (performance.Audience - 30) * 10;
            }
            return baseAmount;
        }

        public int CalculateCredits(Play play, Performance performance)
        {
            return performance.Audience > 30 ? performance.Audience - 30 : 0;
        }
    }
}
