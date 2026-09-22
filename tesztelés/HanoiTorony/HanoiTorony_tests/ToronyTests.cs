using HanoiTorony_lib;
namespace HanoiTorony_tests
{
    public class ToronyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetUpTest()
        {
            Torony tornyok = new Torony(3);

            Assert.That(tornyok.ToronyA.Count(), Is.EqualTo(3));
            Assert.That(tornyok.ToronyB.Count(), Is.EqualTo(0));
            Assert.That(tornyok.ToronyC.Count(), Is.EqualTo(0));
        }

        [Test]
        public void FalsityMoveTest()
        {
            Torony tornyok = new Torony(3);
            tornyok.Mozgat("a", "v");

            Assert.That(tornyok.ToronyA.Count(), Is.EqualTo(3));
            Assert.That(tornyok.ToronyB.Count(), Is.EqualTo(0));
            Assert.That(tornyok.ToronyC.Count(), Is.EqualTo(0));
        }

        [Test]
        public void SameRodMoveTest()
        {
            Torony tornyok = new Torony(3);
            tornyok.Mozgat("a", "a");

            Assert.That(tornyok.ToronyA.Count(), Is.EqualTo(3));
            Assert.That(tornyok.ToronyB.Count(), Is.EqualTo(0));
            Assert.That(tornyok.ToronyC.Count(), Is.EqualTo(0));
        }

        [Test]
        public void EmptyRodMoveTest()
        {
            Torony tornyok = new Torony(3);
            tornyok.Mozgat("b", "c");

            Assert.That(tornyok.ToronyA.Count(), Is.EqualTo(3));
            Assert.That(tornyok.ToronyB.Count(), Is.EqualTo(0));
            Assert.That(tornyok.ToronyC.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ValildMoveTest()
        {
            Torony tornyok = new Torony(3);
            tornyok.Mozgat("a", "b");

            Assert.That(tornyok.ToronyA.Count(), Is.EqualTo(2));
            Assert.That(tornyok.ToronyB.Count(), Is.EqualTo(1));
            Assert.That(tornyok.ToronyC.Count(), Is.EqualTo(0));
        }

        [Test]
        public void WinConditionTest()
        {
            Torony tornyok = new Torony(2);
            tornyok.Mozgat("a", "b");
            tornyok.Mozgat("a", "c");
            tornyok.Mozgat("b", "c");

            Assert.That(tornyok.ToronyA.Count(), Is.EqualTo(0));
            Assert.That(tornyok.ToronyB.Count(), Is.EqualTo(0));
            Assert.That(tornyok.ToronyC.Count(), Is.EqualTo(2));
            tornyok.WinCon();
            Assert.That(tornyok.GameState, Is.False);

        }
    }
}
