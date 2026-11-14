using Urhajok_lib;

namespace Urhajok_tests
{
    public class SkillTests
    {
        [Test]
        public void ValidSkill()
        {
            Skill skill = new Skill("navigáció", 2);

            Assert.That(skill.Name, Is.EqualTo("navigáció"));
            Assert.That(skill.Level, Is.EqualTo(2));
        }

        [Test]
        public void SkillNameEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Skill("", 1));
        }

        [Test]
        public void SkillNameWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Skill("   ", 1));
        }

        [Test]
        public void SkillLevelNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Skill("navigáció", -1));
        }

        [Test]
        public void SkillLevelZero()
        {
            Skill skill = new Skill("navigáció", 0);

            Assert.That(skill.Level, Is.EqualTo(0));
        }
    }
}