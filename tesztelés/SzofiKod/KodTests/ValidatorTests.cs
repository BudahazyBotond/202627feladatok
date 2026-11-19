using SzofiKod_lib;
namespace KodTests
{
    public class ValidatorTests
    {
        [Test]
        public void Valid1()
        {
            KodValidalas Kod = new("KGCW-5321-JUAH");
            Assert.That(Kod.Validate());
        }
        [Test]
        public void Valid2()
        {
            KodValidalas Kod = new("AAAA-BBBB-JCG1");
            Assert.That(Kod.Validate());
        }
        [Test]
        public void InvalidEmpty()
        {
            KodValidalas Kod = new("");
            Assert.That(!Kod.Validate());
        }
        [Test]
        public void InvalidNoRequiredLetters()
        {
            KodValidalas Kod = new("AAAA-BBBB-CCCC");
            Assert.That(!Kod.Validate());
        }
        [Test]
        public void InvalidWrongDashPlacement()
        {
            KodValidalas Kod = new("--GGJJCCCC1234");
            Assert.That(!Kod.Validate());
        }
        [Test]
        public void InvalidTooManyJ()
        {
            KodValidalas Kod = new("ggjj-cccc-1234");
            Assert.That(!Kod.Validate());
        }
        [Test]
        public void ValidNoDash()
        {
            KodValidalas Kod = new("CAJAVALA78G1");
            Assert.That(Kod.Validate());
        }
        [Test]
        public void InvalidTooManyDashes()
        {
            KodValidalas Kod = new("AA-AA-GC-GG-5J-T0");
            Assert.That(!Kod.Validate());
        }
        [Test]
        public void InvalidTooFewCharacters()
        {
            KodValidalas Kod = new("CAJAVA78G");
            Assert.That(!Kod.Validate());
        }
        [Test]
        public void InvalidTooLong()
        {
            KodValidalas Kod = new("ACA-UU1G-1MOP1");
            Assert.That(!Kod.Validate());
        }
        [Test]
        public void InvalidWrongDashAndTooLong()
        {
            KodValidalas Kod = new("JACA-UU1G1MOP1");
            Assert.That(!Kod.Validate());
        }
    }
}
