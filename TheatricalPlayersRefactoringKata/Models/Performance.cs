using System;
using System.Text.Json.Serialization;

namespace TheatricalPlayersRefactoringKata.Models;
public class Performance
{

    [JsonPropertyName("playId")]
    public string PlayId { get; set; }
    
    [JsonPropertyName("audience")]
    public int Audience { get; set; }

    public Performance(string playId, int audience)
    {
        if (audience < 0) throw new ArgumentException("Audience cannot be negative");
        PlayId = playId;
        Audience = audience;
    }
}
