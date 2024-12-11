using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Models;
public class Invoice
{
    private string Customer { get; set; }
    private List<Performance> Performances { get; set; }

}
