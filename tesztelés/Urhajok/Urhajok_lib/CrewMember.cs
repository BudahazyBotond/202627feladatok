namespace Urhajok_lib
{
    public class CrewMember
    {
        private string _name;
        private string _nationality;
        private string _gender;
        private List<Skill> _skills;

        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                _name = value;
            }
        }

        public string Nationality
        {
            get => _nationality;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                _nationality = value;
            }
        }

        public DateTime BirthDate { get; init; }

        public string Gender
        {
            get => _gender;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                _gender = value;
            }
        }

        public IReadOnlyList<Skill> Skills => _skills.AsReadOnly();

        public Spaceship? AssignedShip { get; internal set; }

        public bool IsAssigned => AssignedShip != null;

        public CrewMember(string name, string nationality, DateTime birthDate, string gender, IEnumerable<Skill>? skills = null)
        {
            Name = name;
            Nationality = nationality;
            BirthDate = birthDate;
            Gender = gender;
            _skills = skills != null ? new List<Skill>(skills) : new List<Skill>();
        }

        public int GetSkillLevel(string skillName)
        {
            return _skills.Where(s => s.Name == skillName).Sum(s => s.Level);
        }
    }
}