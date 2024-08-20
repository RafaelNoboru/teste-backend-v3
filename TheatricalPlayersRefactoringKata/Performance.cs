using TheatricalPlayersRefactoringKata;

public class Performance
{
    public string PlayId { get; }
    public int Audience { get; }
    public Play Play { get; }

    public Performance(string playId, int audience, Play play)
    {
        PlayId = playId;
        Audience = audience;
        Play = play;
    }
}