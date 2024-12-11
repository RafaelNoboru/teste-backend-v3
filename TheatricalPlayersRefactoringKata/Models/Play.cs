using TheatricalPlayersRefactoringKata.Enum;

namespace TheatricalPlayersRefactoringKata.Models;
public class Play
{
    public string Name { get; set; }
    public int Lines { get; set; }
    public Type Type { get; set; }

    public Play(string name, int lines, Type type)
    {
        Name = name;
        Lines = lines;
        Type = type;
    }
}
