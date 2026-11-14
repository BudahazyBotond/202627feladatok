using Urhajok_lib;

namespace Urhajok_tests
{
    public class SpaceshipTests
    {
        private static ShipType CreateShipType()
        {
            return new ShipType("felderítő", "mélységi felderítő űrhajó",
                new List<Skill> { new Skill("navigáció", 2) });
        }

        private static Spaceship CreateShip(int capacity = 3)
        {
            return new Spaceship("Kutató 11", "felfedező", CreateShipType(), 2020, capacity);
        }

        [Test]
        public void ValidSpaceship()
        {
            Spaceship ship = CreateShip();

            Assert.That(ship.Name, Is.EqualTo("Kutató 11"));
            Assert.That(ship.ShipClass, Is.EqualTo("felfedező"));
            Assert.That(ship.Type.Name, Is.EqualTo("felderítő"));
            Assert.That(ship.ProductionYear, Is.EqualTo(2020));
            Assert.That(ship.Capacity, Is.EqualTo(3));
            Assert.That(ship.Crew.Count, Is.EqualTo(0));
            Assert.That(ship.FreeSlots, Is.EqualTo(3));
        }

        [Test]
        public void SpaceshipNameEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new Spaceship("", "felfedező", CreateShipType(), 2020, 3));
        }

        [Test]
        public void SpaceshipClassNameEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new Spaceship("Kutató 11", "", CreateShipType(), 2020, 3));
        }

        [Test]
        public void SpaceshipTypeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Spaceship("Kutató 11", "felfedező", null!, 2020, 3));
        }

        [Test]
        public void SpaceshipCapacityZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Spaceship("Kutató 11", "felfedező", CreateShipType(), 2020, 0));
        }

        [Test]
        public void SpaceshipCapacityNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Spaceship("Kutató 11", "felfedező", CreateShipType(), 2020, -1));
        }

        [Test]
        public void SpaceshipProductionYearTooOld()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Spaceship("Kutató 11", "felfedező", CreateShipType(), 1800, 3));
        }

        [Test]
        public void AddCrewMember()
        {
            Spaceship ship = CreateShip();
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi");

            Assert.That(ship.AddCrew(member), Is.True);
            Assert.That(ship.Crew.Count, Is.EqualTo(1));
            Assert.That(ship.FreeSlots, Is.EqualTo(2));
            Assert.That(member.IsAssigned, Is.True);
            Assert.That(member.AssignedShip, Is.EqualTo(ship));
        }

        [Test]
        public void AddCrewMemberNull()
        {
            Spaceship ship = CreateShip();

            Assert.Throws<ArgumentNullException>(() => ship.AddCrew(null!));
        }

        [Test]
        public void AddCrewMemberWhenFull()
        {
            Spaceship ship = CreateShip(1);
            CrewMember member1 = new CrewMember("John", "amerikai", DateTime.Now, "férfi");
            CrewMember member2 = new CrewMember("Jane", "brit", DateTime.Now, "nő");

            ship.AddCrew(member1);

            Assert.That(ship.AddCrew(member2), Is.False);
            Assert.That(ship.Crew.Count, Is.EqualTo(1));
            Assert.That(member2.IsAssigned, Is.False);
        }

        [Test]
        public void AddAlreadyAssignedCrewMember()
        {
            Spaceship ship1 = CreateShip();
            Spaceship ship2 = CreateShip();
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi");

            ship1.AddCrew(member);

            Assert.That(ship2.AddCrew(member), Is.False);
            Assert.That(ship2.Crew.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveCrewMember()
        {
            Spaceship ship = CreateShip();
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi");
            ship.AddCrew(member);

            Assert.That(ship.RemoveCrew(member), Is.True);
            Assert.That(ship.Crew.Count, Is.EqualTo(0));
            Assert.That(member.IsAssigned, Is.False);
            Assert.That(member.AssignedShip, Is.Null);
        }

        [Test]
        public void RemoveNonExistentCrewMember()
        {
            Spaceship ship = CreateShip();
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi");

            Assert.That(ship.RemoveCrew(member), Is.False);
        }

        [Test]
        public void CannotLaunchWithoutCrew()
        {
            Spaceship ship = CreateShip();

            Assert.That(ship.CanLaunch(), Is.False);
        }

        [Test]
        public void CannotLaunchWithInsufficientSkills()
        {
            Spaceship ship = CreateShip();
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi",
                new List<Skill> { new Skill("navigáció", 1) });
            ship.AddCrew(member);

            Assert.That(ship.CanLaunch(), Is.False);
        }

        [Test]
        public void CanLaunchWithSufficientSkills()
        {
            Spaceship ship = CreateShip();
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi",
                new List<Skill> { new Skill("navigáció", 3) });
            ship.AddCrew(member);

            Assert.That(ship.CanLaunch(), Is.True);
        }

        [Test]
        public void CannotLaunchWhenSkillLevelEqualsRequirement()
        {
            Spaceship ship = CreateShip();
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi",
                new List<Skill> { new Skill("navigáció", 2) });
            ship.AddCrew(member);

            // A követelmény: összeg > elvárt érték, tehát 2 > 2 hamis
            Assert.That(ship.CanLaunch(), Is.False);
        }

        [Test]
        public void CanLaunchWithMultipleCrewMembersSkillsSummed()
        {
            Spaceship ship = CreateShip();
            CrewMember member1 = new CrewMember("John", "amerikai", DateTime.Now, "férfi",
                new List<Skill> { new Skill("navigáció", 1) });
            CrewMember member2 = new CrewMember("Jane", "brit", DateTime.Now, "nő",
                new List<Skill> { new Skill("navigáció", 2) });
            ship.AddCrew(member1);
            ship.AddCrew(member2);

            Assert.That(ship.CanLaunch(), Is.True);
        }

        [Test]
        public void CannotLaunchWhenMultipleSkillsRequiredAndOneIsInsufficient()
        {
            ShipType type = new ShipType("felderítő", "leírás",
                new List<Skill> { new Skill("navigáció", 2), new Skill("diplomácia", 1) });
            Spaceship ship = new Spaceship("Kutató 11", "felfedező", type, 2020, 3);
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi",
                new List<Skill> { new Skill("navigáció", 3), new Skill("diplomácia", 1) });
            ship.AddCrew(member);

            Assert.That(ship.CanLaunch(), Is.False);
        }

        [Test]
        public void CanLaunchWithNoRequiredSkills()
        {
            ShipType type = new ShipType("felderítő", "leírás");
            Spaceship ship = new Spaceship("Kutató 11", "felfedező", type, 2020, 3);
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi");
            ship.AddCrew(member);

            Assert.That(ship.CanLaunch(), Is.True);
        }
    }
}