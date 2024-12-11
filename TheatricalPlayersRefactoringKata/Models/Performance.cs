namespace TheatricalPlayersRefactoringKata.Models;
public class Performance
{
    public string PlayId { get; set; }
    public int Audience { get; set; }
    public Play Play { get; set; }

    public Performance(string playId, int audience)
    {
        PlayId = playId;
        Audience = audience;
    }
}
