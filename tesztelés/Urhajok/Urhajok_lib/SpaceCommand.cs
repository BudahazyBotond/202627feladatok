namespace Urhajok_lib
{
    public class SpaceCommand
    {
        private List<Spaceship> _ships;
        private List<CrewMember> _crewMembers;

        public IReadOnlyList<Spaceship> Ships => _ships.AsReadOnly();

        public IReadOnlyList<CrewMember> FreeCrewMembers => _crewMembers.Where(c => !c.IsAssigned).ToList().AsReadOnly();

        public SpaceCommand()
        {
            _ships = new List<Spaceship>();
            _crewMembers = new List<CrewMember>();
        }

        public void AddShip(Spaceship ship)
        {
            if (ship == null)
            {
                throw new ArgumentNullException(nameof(ship));
            }

            if (_ships.Any(s => s.Name == ship.Name))
            {
                throw new ArgumentException("A ship with this name already exists.");
            }

            _ships.Add(ship);
        }

        public void AddCrewMember(CrewMember member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            _crewMembers.Add(member);
        }

        public Spaceship? FindShip(string name)
        {
            return _ships.FirstOrDefault(s => s.Name == name);
        }

        public CrewMember? FindCrewMember(string name)
        {
            return _crewMembers.FirstOrDefault(c => c.Name == name);
        }

        public bool AssignCrewToShip(string crewName, string shipName)
        {
            CrewMember? member = FindCrewMember(crewName);
            Spaceship? ship = FindShip(shipName);

            if (member == null || ship == null)
            {
                return false;
            }

            return ship.AddCrew(member);
        }

        public bool RemoveCrewFromShip(string crewName)
        {
            CrewMember? member = FindCrewMember(crewName);

            if (member == null || member.AssignedShip == null)
            {
                return false;
            }

            return member.AssignedShip.RemoveCrew(member);
        }

        public bool TransferCrew(string crewName, string newShipName)
        {
            CrewMember? member = FindCrewMember(crewName);
            Spaceship? newShip = FindShip(newShipName);

            if (member == null || newShip == null || !member.IsAssigned)
            {
                return false;
            }

            if (newShip.Crew.Contains(member))
            {
                return false;
            }

            if (newShip.FreeSlots <= 0)
            {
                return false;
            }

            member.AssignedShip!.RemoveCrew(member);
            return newShip.AddCrew(member);
        }
    }
}