namespace Urhajok_lib
{
    public class ShipType
    {
        private string _name;
        private string _description;
        private List<Skill> _requiredSkills;

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

        public string Description
        {
            get => _description;
            init
            {
                _description = value ?? "";
            }
        }

        public IReadOnlyList<Skill> RequiredSkills => _requiredSkills.AsReadOnly();

        public ShipType(string name, string description, IEnumerable<Skill>? requiredSkills = null)
        {
            Name = name;
            Description = description;
            _requiredSkills = requiredSkills != null ? new List<Skill>(requiredSkills) : new List<Skill>();
        }
    }
}