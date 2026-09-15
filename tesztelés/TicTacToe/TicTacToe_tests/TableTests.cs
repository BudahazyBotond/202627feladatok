using TicTacToe_lib;
using NUnit;
namespace TicTacToe_tests
{
    public class TableTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyTablePrint()
        {
            Table table = new Table();
            string printedTalbe = table.PrintTable();

            Assert.That(printedTalbe,Is.EqualTo(
                "[_][_][_]\n" +
                "[_][_][_]\n" +
                "[_][_][_]"));
        }

        [Test]
        public void PutTableTest()
        {
            Table table = new Table();
            table.PutTable(0, 'X');
            string printedTalbe = table.PrintTable();

            Assert.That(printedTalbe, Is.EqualTo(
                "[X][_][_]\n" +
                "[_][_][_]\n" +
                "[_][_][_]"));
        }

        [Test]
        public void PutOnOccupiedSpaceTableTest()
        {
            Table table = new Table();
            table.PutTable(0, 'X');
            string printedTalbe = table.PrintTable();

            Assert.That(table.PutTable(0, 'O'), Is.False);
            Assert.That(printedTalbe, Is.EqualTo(
                "[X][_][_]\n" +
                "[_][_][_]\n" +
                "[_][_][_]"));
        }
        [Test]
        public void PutOnInvalidIndexTableTest()
        {
            Table table = new Table();
            Assert.That(table.PutTable(-1, 'X'), Is.False);
            Assert.That(table.PutTable(9, 'O'), Is.False);
        }

        [Test]
        public void IsFullTableTest()
        {
            Table table = new Table();
            Assert.That(table.IsFull(), Is.False);
            for (int i = 0; i < 9; i++)
            {
                table.PutTable(i, 'X');
            }
            Assert.That(table.IsFull(), Is.True);
        }

        [Test]
        public void IndexerTest()
        {
            Table table = new Table();
            table.PutTable(0, 'X');
            Assert.That(table[0], Is.EqualTo('X'));
            Assert.That(table[1], Is.EqualTo('_'));
        }
    }
}
