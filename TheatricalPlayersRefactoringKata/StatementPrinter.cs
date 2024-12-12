using System;
using System.Collections.Generic;
using System.Globalization;
using TheatricalPlayersRefactoringKata.Interface;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata;
public class StatementPrinter
{
        private readonly IStatementFormatter _formatter;

        public StatementPrinter(IStatementFormatter formatter)
        {
            _formatter = formatter;
        }

        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            return _formatter.Format(invoice, plays);
        }
}
