using NUnit;
using TicTacToe_lib;
namespace TicTacToe_tests;
public class GameTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConvertInputToIndexTest()
    {
        Game game = new Game();
        int index = game.ConvertInputToIndex("2 3");
        Assert.That(index, Is.EqualTo(5));
    }
    [Test]
    public void PutTableWithInputConverterTest()
    {
        Game game = new Game();
        game.PutTable("2 2");
        string printedTalbe = game.PrintTable();

        Assert.That(printedTalbe, Is.EqualTo(
            "[_][_][_]\n" +
            "[_][X][_]\n" +
            "[_][_][_]"));
    }
    [Test]
    public void OverwritePutTableTest()
    {
        Game game = new Game();
        game.PutTable("2 2");
        string printedTalbe = game.PrintTable();
        game.PutTable("2 2");
        printedTalbe = game.PrintTable();

        Assert.That(printedTalbe, Is.EqualTo(
            "[_][_][_]\n" +
            "[_][X][_]\n" +
            "[_][_][_]"));

        game.PutTable("2 3");
        printedTalbe = game.PrintTable();

        Assert.That(printedTalbe, Is.EqualTo(
            "[_][_][_]\n" +
            "[_][X][O]\n" +
            "[_][_][_]"));
    }
    [Test]
    public void CheckWinTest()
    {
        Game game = new Game();
        game.PutTable("1 1");
        game.PutTable("3 1");
        game.PutTable("1 2");
        game.PutTable("3 2");
        game.PutTable("1 3");
        (bool isWin, char winner) = game.CheckWin();
        Assert.That(isWin, Is.True);
        Assert.That(winner, Is.EqualTo('X'));
    }
    [Test]
    public void CheckDrawTest()
    {
        Game game = new Game();
        game.PutTable("1 1");
        game.PutTable("1 2");
        game.PutTable("1 3");
        game.PutTable("3 1");
        game.PutTable("3 2");
        game.PutTable("3 3");
        game.PutTable("2 1");
        game.PutTable("2 2");
        game.PutTable("2 3");
        bool isDraw = game.CheckDraw();
        Assert.That(isDraw, Is.True);
    }

}
