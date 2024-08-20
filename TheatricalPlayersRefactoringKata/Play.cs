using System;

namespace TheatricalPlayersRefactoringKata
{
    public enum PlayType
    {
        Tragedy,
        Comedy,
        Historical
    }

    public class Play
    {
        public string Name { get; }
        private int _lines;
        public int Lines
        {
            get => _lines;
            private set => _lines = Math.Clamp(value, 1000, 4000);
        }
        public PlayType Type { get; }

        public Play(string name, int lines, PlayType type)
        {
            Name = name;
            Lines = lines;  
            Type = type;
        }
    }
}

