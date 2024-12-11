using TheatricalPlayersRefactoringKata.Enum;

namespace TheatricalPlayersRefactoringKata.Models;
public class Play
{
    public string Name { get; private set; }
    public int Lines { get; private set; }
    public Type Type { get; private set; }

    public Play(string name, int lines, Type type)
    {
        Name = name;
        Lines = lines;
        Type = type;
    }
}
