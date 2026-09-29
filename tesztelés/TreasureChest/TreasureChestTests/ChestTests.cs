using TreasureChest;
namespace TreasureChestTests
{
    public class ChestTests
    {

        [Test]
        public void ChestVolumeZero()
        {
            Chest chest = new Chest("láda", 0);

            Assert.That(chest.Volume, Is.EqualTo(0));
        }

        [Test]
        public void ValidChest()
        {
            Chest chest = new Chest("láda", 1);

            Assert.That(chest.Volume, Is.EqualTo(1));
            Assert.That(chest.Name, Is.EqualTo("láda"));
        }

        [Test]
        public void ChestVolumeMinus()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Chest("láda", -1));
        }

        [Test]
        public void OpenLockedClosedChest()
        {
            Chest chest = new Chest("láda", 1);

            Assert.That(chest.Open(), Is.False);
        }

        [Test]
        public void OpenUnlockedOpenedChest()
        {
            Chest chest = new Chest("láda", 1);

            chest.UnLock();
            chest.Open();

            Assert.That(chest.Open(), Is.False);
        }

        [Test]
        public void OpenUnlockedClosedChest()
        {
            Chest chest = new Chest("láda", 1);

            chest.UnLock();

            Assert.That(chest.Open(), Is.True);
        }

        [Test]
        public void CloseLockedClosedChest()
        {
            Chest chest = new Chest("láda", 1);

            Assert.That(chest.Close(), Is.False);
        }

        [Test]
        public void CloseUnlockedClosedChest()
        {
            Chest chest = new Chest("láda", 1);

            chest.UnLock();

            Assert.That(chest.Close(), Is.False);
        }

        [Test]
        public void CloseUnlockedOpenedChest()
        {
            Chest chest = new Chest("láda", 1);

            chest.UnLock();
            chest.Open();

            Assert.That(chest.Close(), Is.True);
        }


        [Test]
        public void UnlockLockedClosedChest()
        {
            Chest chest = new Chest("láda", 1);

            Assert.That(chest.UnLock(), Is.True);
        }

        [Test]
        public void UnlockUnlockedClosedChest()
        {
            Chest chest = new Chest("láda", 1);

            chest.UnLock();

            Assert.That(chest.UnLock(), Is.False);
        }

        [Test]
        public void UnlockUnlockedOpenedChest()
        {
            Chest chest = new Chest("láda", 1);

            chest.UnLock();
            chest.Open();

            Assert.That(chest.UnLock(), Is.False);
        }

        [Test]
        public void LockLockedClosedChest()
        {
            Chest chest = new Chest("láda", 1);

            Assert.That(chest.Lock(), Is.False);
        }

        [Test]
        public void LockUnlockedClosedChest()
        {
            Chest chest = new Chest("láda", 1);

            chest.UnLock();

            Assert.That(chest.Lock(), Is.True);
        }

        [Test]
        public void LockUnlockedOpenedChest()
        {
            Chest chest = new Chest("láda", 1);

            chest.UnLock();
            chest.Open();

            Assert.That(chest.Lock(), Is.False);
        }

        [Test]
        public void ValidStoreChest()
        {
            Chest chest = new Chest("láda", 1);
            Treasure treasure = new("arany", 1);

            chest.UnLock();
            chest.Open();


            Assert.That(chest.Store(treasure), Is.True);
        }
    }
}
