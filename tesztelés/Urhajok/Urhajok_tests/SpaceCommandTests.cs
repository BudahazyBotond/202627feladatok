using Urhajok_lib;

namespace Urhajok_tests
{
    public class SpaceCommandTests
    {
        private static ShipType CreateShipType()
        {
            return new ShipType("felderítő", "mélységi felderítő űrhajó",
                new List<Skill> { new Skill("navigáció", 2) });
        }

        private static Spaceship CreateShip(string name = "Kutató 11", int capacity = 3)
        {
            return new Spaceship(name, "felfedező", CreateShipType(), 2020, capacity);
        }

        private static CrewMember CreateCrewMember(string name = "John Smith")
        {
            return new CrewMember(name, "amerikai", new DateTime(2001, 11, 2), "férfi",
                new List<Skill> { new Skill("diplomácia", 1), new Skill("navigáció", 2) });
        }

        [Test]
        public void AddShip()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship = CreateShip();

            command.AddShip(ship);

            Assert.That(command.Ships.Count, Is.EqualTo(1));
            Assert.That(command.Ships[0].Name, Is.EqualTo("Kutató 11"));
        }

        [Test]
        public void AddShipNull()
        {
            SpaceCommand command = new SpaceCommand();

            Assert.Throws<ArgumentNullException>(() => command.AddShip(null!));
        }

        [Test]
        public void AddDuplicateShipName()
        {
            SpaceCommand command = new SpaceCommand();
            command.AddShip(CreateShip("Kutató 11"));

            Assert.Throws<ArgumentException>(() => command.AddShip(CreateShip("Kutató 11")));
        }

        [Test]
        public void AddCrewMember()
        {
            SpaceCommand command = new SpaceCommand();
            CrewMember member = CreateCrewMember();

            command.AddCrewMember(member);

            Assert.That(command.FreeCrewMembers.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddCrewMemberNull()
        {
            SpaceCommand command = new SpaceCommand();

            Assert.Throws<ArgumentNullException>(() => command.AddCrewMember(null!));
        }

        [Test]
        public void FindShipByName()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship = CreateShip();
            command.AddShip(ship);

            Assert.That(command.FindShip("Kutató 11"), Is.EqualTo(ship));
        }

        [Test]
        public void FindShipNotFound()
        {
            SpaceCommand command = new SpaceCommand();

            Assert.That(command.FindShip("nincs"), Is.Null);
        }

        [Test]
        public void FindCrewMemberByName()
        {
            SpaceCommand command = new SpaceCommand();
            CrewMember member = CreateCrewMember();
            command.AddCrewMember(member);

            Assert.That(command.FindCrewMember("John Smith"), Is.EqualTo(member));
        }

        [Test]
        public void AssignCrewToShip()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship = CreateShip();
            CrewMember member = CreateCrewMember();
            command.AddShip(ship);
            command.AddCrewMember(member);

            Assert.That(command.AssignCrewToShip("John Smith", "Kutató 11"), Is.True);
            Assert.That(ship.Crew.Count, Is.EqualTo(1));
            Assert.That(member.IsAssigned, Is.True);
            Assert.That(command.FreeCrewMembers.Count, Is.EqualTo(0));
        }

        [Test]
        public void AssignCrewToShipUnknownCrew()
        {
            SpaceCommand command = new SpaceCommand();
            command.AddShip(CreateShip());

            Assert.That(command.AssignCrewToShip("nincs", "Kutató 11"), Is.False);
        }

        [Test]
        public void AssignCrewToShipUnknownShip()
        {
            SpaceCommand command = new SpaceCommand();
            command.AddCrewMember(CreateCrewMember());

            Assert.That(command.AssignCrewToShip("John Smith", "nincs"), Is.False);
        }

        [Test]
        public void AssignCrewToFullShip()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship = CreateShip(capacity: 1);
            CrewMember member1 = CreateCrewMember("John Smith");
            CrewMember member2 = CreateCrewMember("Jane Doe");
            command.AddShip(ship);
            command.AddCrewMember(member1);
            command.AddCrewMember(member2);
            command.AssignCrewToShip("John Smith", "Kutató 11");

            Assert.That(command.AssignCrewToShip("Jane Doe", "Kutató 11"), Is.False);
            Assert.That(ship.Crew.Count, Is.EqualTo(1));
        }

        [Test]
        public void AssignAlreadyAssignedCrewToAnotherShip()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship1 = CreateShip("Kutató 11");
            Spaceship ship2 = CreateShip("Kutató 12");
            CrewMember member = CreateCrewMember();
            command.AddShip(ship1);
            command.AddShip(ship2);
            command.AddCrewMember(member);
            command.AssignCrewToShip("John Smith", "Kutató 11");

            Assert.That(command.AssignCrewToShip("John Smith", "Kutató 12"), Is.False);
            Assert.That(ship1.Crew.Count, Is.EqualTo(1));
            Assert.That(ship2.Crew.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveCrewFromShip()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship = CreateShip();
            CrewMember member = CreateCrewMember();
            command.AddShip(ship);
            command.AddCrewMember(member);
            command.AssignCrewToShip("John Smith", "Kutató 11");

            Assert.That(command.RemoveCrewFromShip("John Smith"), Is.True);
            Assert.That(ship.Crew.Count, Is.EqualTo(0));
            Assert.That(member.IsAssigned, Is.False);
            Assert.That(command.FreeCrewMembers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveCrewFromShipUnknownCrew()
        {
            SpaceCommand command = new SpaceCommand();

            Assert.That(command.RemoveCrewFromShip("nincs"), Is.False);
        }

        [Test]
        public void RemoveCrewFromShipNotAssigned()
        {
            SpaceCommand command = new SpaceCommand();
            command.AddCrewMember(CreateCrewMember());

            Assert.That(command.RemoveCrewFromShip("John Smith"), Is.False);
        }

        [Test]
        public void TransferCrew()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship1 = CreateShip("Kutató 11");
            Spaceship ship2 = CreateShip("Kutató 12");
            CrewMember member = CreateCrewMember();
            command.AddShip(ship1);
            command.AddShip(ship2);
            command.AddCrewMember(member);
            command.AssignCrewToShip("John Smith", "Kutató 11");

            Assert.That(command.TransferCrew("John Smith", "Kutató 12"), Is.True);
            Assert.That(ship1.Crew.Count, Is.EqualTo(0));
            Assert.That(ship2.Crew.Count, Is.EqualTo(1));
            Assert.That(member.AssignedShip, Is.EqualTo(ship2));
        }

        [Test]
        public void TransferCrewToFullShip()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship1 = CreateShip("Kutató 11");
            Spaceship ship2 = CreateShip("Kutató 12", capacity: 1);
            CrewMember member1 = CreateCrewMember("John Smith");
            CrewMember member2 = CreateCrewMember("Jane Doe");
            command.AddShip(ship1);
            command.AddShip(ship2);
            command.AddCrewMember(member1);
            command.AddCrewMember(member2);
            command.AssignCrewToShip("John Smith", "Kutató 11");
            command.AssignCrewToShip("Jane Doe", "Kutató 12");

            Assert.That(command.TransferCrew("John Smith", "Kutató 12"), Is.False);
            Assert.That(ship1.Crew.Count, Is.EqualTo(1));
            Assert.That(ship2.Crew.Count, Is.EqualTo(1));
        }

        [Test]
        public void TransferCrewNotAssigned()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship = CreateShip();
            command.AddShip(ship);
            command.AddCrewMember(CreateCrewMember());

            Assert.That(command.TransferCrew("John Smith", "Kutató 11"), Is.False);
        }

        [Test]
        public void TransferCrewUnknownCrew()
        {
            SpaceCommand command = new SpaceCommand();
            command.AddShip(CreateShip());

            Assert.That(command.TransferCrew("nincs", "Kutató 11"), Is.False);
        }

        [Test]
        public void TransferCrewUnknownShip()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship = CreateShip();
            CrewMember member = CreateCrewMember();
            command.AddShip(ship);
            command.AddCrewMember(member);
            command.AssignCrewToShip("John Smith", "Kutató 11");

            Assert.That(command.TransferCrew("John Smith", "nincs"), Is.False);
        }

        [Test]
        public void TransferCrewToSameShip()
        {
            SpaceCommand command = new SpaceCommand();
            Spaceship ship = CreateShip();
            CrewMember member = CreateCrewMember();
            command.AddShip(ship);
            command.AddCrewMember(member);
            command.AssignCrewToShip("John Smith", "Kutató 11");

            Assert.That(command.TransferCrew("John Smith", "Kutató 11"), Is.False);
        }

        [Test]
        public void FullScenarioFromPdf()
        {
            ShipType type = new ShipType("felderítő", "mélységi felderítő űrhajó, mélyűri felfedezésekhez.",
                new List<Skill> { new Skill("navigáció", 2) });
            Spaceship ship = new Spaceship("Kutató 11", "felfedező", type, 2020, 5);
            CrewMember member = new CrewMember("John Smith", "amerikai",
                new DateTime(2001, 11, 2), "férfi",
                new List<Skill> { new Skill("diplomácia", 1), new Skill("navigáció", 2) });

            SpaceCommand command = new SpaceCommand();
            command.AddShip(ship);
            command.AddCrewMember(member);

            Assert.That(command.AssignCrewToShip("John Smith", "Kutató 11"), Is.True);
            Assert.That(ship.CanLaunch(), Is.False);
        }

        [Test]
        public void FullScenarioWithLaunchableShip()
        {
            ShipType type = new ShipType("felderítő", "mélységi felderítő űrhajó",
                new List<Skill> { new Skill("navigáció", 2) });
            Spaceship ship = new Spaceship("Kutató 11", "felfedező", type, 2020, 5);
            CrewMember member = new CrewMember("John Smith", "amerikai",
                new DateTime(2001, 11, 2), "férfi",
                new List<Skill> { new Skill("navigáció", 3) });

            SpaceCommand command = new SpaceCommand();
            command.AddShip(ship);
            command.AddCrewMember(member);
            command.AssignCrewToShip("John Smith", "Kutató 11");

            Assert.That(ship.CanLaunch(), Is.True);
        }
    }
}