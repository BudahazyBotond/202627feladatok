using TreasureChest;

namespace TreasureChestTests
{
    public class TreasureTests
    {
        [Test]
        public void ValidTreasure()
        {
            Treasure treasure = new("arany", 1);

            Assert.That(treasure.Name, Is.EqualTo("arany"));
            Assert.That(treasure.Volume, Is.EqualTo(1));
        }

        [Test]
        public void TreasureVolumeZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Treasure("arany", 0));
        }

        [Test]
        public void TreasureVolumeMinus()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Treasure("arany", -1));
        }
    }
}
