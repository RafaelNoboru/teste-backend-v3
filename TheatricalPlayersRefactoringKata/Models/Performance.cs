using System;

namespace TheatricalPlayersRefactoringKata.Models;
public class Performance
{
    public string PlayId { get; set; }
    public int Audience { get; set; }

    public Performance(string playId, int audience)
    {
        if (audience < 0) throw new ArgumentException("Audience cannot be negative");
        PlayId = playId;
        Audience = audience;
    }
}
