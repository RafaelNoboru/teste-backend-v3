namespace TheatricalPlayersRefactoringKata.Models;
public class Performance
{
    private string PlayId { get; set; }
    private int Audience { get; set; }
    public Play Play { get; set; }

}
