using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Interface
{
    public interface IGenreCalculator
    {
        decimal CalculateAmount(Play play, Performance performance);
        int CalculateCredits(Play play, Performance performance);
    }
}
