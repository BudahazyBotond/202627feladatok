namespace HungarianKings_LIB
{
    public class Kiraly
    {

        public int Id { get; init; }
        public string Name { get; init; }
        public string? Nickname { get; init; }
        public int Born { get; init; }
        public int Died { get; init; }
        public string House { get; init; }
        public int Start { get; init; }
        public int End { get; init; }
        public int? CrownYear { get; init; }
        public int YearsRuled => End - Start;
        public Kiraly(int id, string name, string? nickname, int born, int died, string house, int start, int end, int? crownYear)
        {
            Id = id;
            Name = name;
            Nickname = nickname;
            Born = born;
            Died = died;
            House = house;
            Start = start;
            End = end;
            CrownYear = crownYear;
        }

        public string FullName()
        {
            return Nickname == null ? Name : $"{Name} ({Nickname})";
        }

        public int AgeAtStart => Start - Born;

        public bool WasBaby()
        {
            return AgeAtStart == 0;
        }

        public bool RuledBeforeCrown()
        {
            if (CrownYear == null) return true;
            return Start < CrownYear;
        }
    }
}