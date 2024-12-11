namespace TheatricalPlayersRefactoringKata.Models;
public class Performance
{
    public string PlayId { get; private set; }
    public int Audience { get;  private set; }
    public Play Play { get; private set; }

    public Performance(string playId, int audience, Play play)
    {
        PlayId = playId;
        Audience = audience;
        Play = play;
    }
}
