using TheatricalPlayersRefactoringKata.Interface;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Calculators
{
    public class HistoricalCalculator : IGenreCalculator
    {
        private readonly TragedyCalculator _tragedyCalculator = new();
        private readonly ComedyCalculator _comedyCalculator = new();

        public decimal CalculateAmount(Play play, Performance performance)
        {
            return _tragedyCalculator.CalculateAmount(play, performance) +
                   _comedyCalculator.CalculateAmount(play, performance);
        }

        public int CalculateCredits(Play play, Performance performance)
        {
            return _tragedyCalculator.CalculateCredits(play, performance) +
                   _comedyCalculator.CalculateCredits(play, performance);
        }
    }
}
