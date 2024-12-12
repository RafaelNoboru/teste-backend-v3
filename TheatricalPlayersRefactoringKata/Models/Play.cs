using System;
using TheatricalPlayersRefactoringKata.Enum;

namespace TheatricalPlayersRefactoringKata.Models;
public class Play
{
    public string Name { get; set; }
    public int Lines { get; set; }
    public PlayType Type { get; set; }

    public Play(string name, int lines, PlayType type)
    {
        if (lines < 1000 || lines > 4000)
            throw new ArgumentException("Lines must be between 1000 and 4000");
        Name = name;
        Lines = lines;
        Type = type;
    }
}
