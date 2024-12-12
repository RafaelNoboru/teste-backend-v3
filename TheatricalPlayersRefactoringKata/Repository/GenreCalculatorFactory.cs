using System;
using TheatricalPlayersRefactoringKata.Interface;
using TheatricalPlayersRefactoringKata.Enum;
using TheatricalPlayersRefactoringKata.Calculators;

namespace TheatricalPlayersRefactoringKata.Repository
{
    public class GenreCalculatorFactory
    {
        public static IGenreCalculator GetCalculator(PlayType playType)
        {
            return playType switch
            {
                PlayType.Tragedy => new TragedyCalculator(),
                PlayType.Comedy => new ComedyCalculator(),
                PlayType.Historical => new HistoricalCalculator(),
                _ => throw new ArgumentException($"Unknown play type: {playType}")
            };
        }
    }
}
