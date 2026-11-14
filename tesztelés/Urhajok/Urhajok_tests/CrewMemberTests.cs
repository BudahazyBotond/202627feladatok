using Urhajok_lib;

namespace Urhajok_tests
{
    public class CrewMemberTests
    {
        [Test]
        public void ValidCrewMember()
        {
            CrewMember member = new CrewMember("John Smith", "amerikai",
                new DateTime(2001, 11, 2), "férfi",
                new List<Skill> { new Skill("diplomácia", 1), new Skill("navigáció", 2) });

            Assert.That(member.Name, Is.EqualTo("John Smith"));
            Assert.That(member.Nationality, Is.EqualTo("amerikai"));
            Assert.That(member.BirthDate, Is.EqualTo(new DateTime(2001, 11, 2)));
            Assert.That(member.Gender, Is.EqualTo("férfi"));
            Assert.That(member.Skills.Count, Is.EqualTo(2));
            Assert.That(member.IsAssigned, Is.False);
        }

        [Test]
        public void CrewMemberNameEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new CrewMember("", "amerikai", DateTime.Now, "férfi"));
        }

        [Test]
        public void CrewMemberNationalityEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new CrewMember("John", "", DateTime.Now, "férfi"));
        }

        [Test]
        public void CrewMemberGenderEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new CrewMember("John", "amerikai", DateTime.Now, ""));
        }

        [Test]
        public void CrewMemberWithoutSkills()
        {
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi");

            Assert.That(member.Skills.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetSkillLevelForExistingSkill()
        {
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi",
                new List<Skill> { new Skill("navigáció", 2) });

            Assert.That(member.GetSkillLevel("navigáció"), Is.EqualTo(2));
        }

        [Test]
        public void GetSkillLevelForNonExistingSkill()
        {
            CrewMember member = new CrewMember("John", "amerikai", DateTime.Now, "férfi");

            Assert.That(member.GetSkillLevel("navigáció"), Is.EqualTo(0));
        }
    }
}