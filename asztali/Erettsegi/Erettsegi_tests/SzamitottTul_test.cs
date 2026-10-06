using Erettsegi_lib;
namespace Erettsegi_tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void VizsgaAzonositok()
    {
        Vizsga vizsga = new Vizsga("1", "10D", "tesi", "10000", "VZS");
        Assert.That(vizsga.Azonosito,Is.EqualTo("Vizsga_1_tesi"));
    }

    [Test]
    public void TeljesOsztaly()
    {
        Vizsgazo vizsgazo = new Vizsgazo("10000", "Kis Sanyi", 10, "D");
        Assert.That(vizsgazo.TeljesOsztaly, Is.EqualTo("10/D"));
    }
}