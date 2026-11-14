namespace Urhajok_lib
{
    public class Spaceship
    {
        private string _name;
        private string _shipClass;
        private List<CrewMember> _crew;

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

        public string ShipClass
        {
            get => _shipClass;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                _shipClass = value;
            }
        }

        public ShipType Type { get; init; }

        public int ProductionYear
        {
            get => _productionYear;
            init
            {
                if (value < 1900 || value > DateTime.Now.Year + 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _productionYear = value;
            }
        }
        private int _productionYear;

        public int Capacity
        {
            get => _capacity;
            init
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _capacity = value;
            }
        }
        private int _capacity;

        public IReadOnlyList<CrewMember> Crew => _crew.AsReadOnly();

        public int FreeSlots => Capacity - _crew.Count;

        public Spaceship(string name, string shipClass, ShipType type, int productionYear, int capacity)
        {
            Name = name;
            ShipClass = shipClass;
            Type = type ?? throw new ArgumentNullException(nameof(type));
            ProductionYear = productionYear;
            Capacity = capacity;
            _crew = new List<CrewMember>();
        }

        public bool AddCrew(CrewMember member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (member.IsAssigned)
            {
                return false;
            }

            if (FreeSlots <= 0)
            {
                return false;
            }

            _crew.Add(member);
            member.AssignedShip = this;
            return true;
        }

        public bool RemoveCrew(CrewMember member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (!_crew.Contains(member))
            {
                return false;
            }

            _crew.Remove(member);
            member.AssignedShip = null;
            return true;
        }

        public bool CanLaunch()
        {
            if (_crew.Count == 0)
            {
                return false;
            }

            foreach (Skill requiredSkill in Type.RequiredSkills)
            {
                int totalLevel = _crew.Sum(member => member.GetSkillLevel(requiredSkill.Name));
                if (totalLevel <= requiredSkill.Level)
                {
                    return false;
                }
            }

            return true;
        }
    }
}