using Urhajok_lib;

namespace Urhajok_tests
{
    public class ShipTypeTests
    {
        [Test]
        public void ValidShipTypeWithSkills()
        {
            ShipType type = new ShipType("felderítő", "mélységi felderítő űrhajó",
                new List<Skill> { new Skill("navigáció", 2) });

            Assert.That(type.Name, Is.EqualTo("felderítő"));
            Assert.That(type.Description, Is.EqualTo("mélységi felderítő űrhajó"));
            Assert.That(type.RequiredSkills.Count, Is.EqualTo(1));
            Assert.That(type.RequiredSkills[0].Name, Is.EqualTo("navigáció"));
            Assert.That(type.RequiredSkills[0].Level, Is.EqualTo(2));
        }

        [Test]
        public void ShipTypeWithoutSkills()
        {
            ShipType type = new ShipType("felderítő", "leírás");

            Assert.That(type.RequiredSkills.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShipTypeNameEmpty()
        {
            Assert.Throws<ArgumentException>(() => new ShipType("", "leírás"));
        }

        [Test]
        public void ShipTypeNameWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new ShipType("   ", "leírás"));
        }

        [Test]
        public void ShipTypeDescriptionNull()
        {
            ShipType type = new ShipType("felderítő", null!);

            Assert.That(type.Description, Is.EqualTo(""));
        }

        [Test]
        public void RequiredSkillsAreCopied()
        {
            List<Skill> skills = new List<Skill> { new Skill("navigáció", 2) };
            ShipType type = new ShipType("felderítő", "leírás", skills);

            skills.Add(new Skill("diplomácia", 1));

            Assert.That(type.RequiredSkills.Count, Is.EqualTo(1));
        }
    }
}