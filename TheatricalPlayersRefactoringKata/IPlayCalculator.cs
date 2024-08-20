using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public interface IPlayCalculator
    {
        int CalculateAmount(Performance performance);
        int CalculateVolumeCredits(Performance performance);
    }
}
