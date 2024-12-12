using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Interface

{
    public interface IStatementFormatter
    {
        string Format(Invoice invoice, Dictionary<string, Play> plays);
    }
}
