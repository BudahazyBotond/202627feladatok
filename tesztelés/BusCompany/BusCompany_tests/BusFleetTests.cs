using BusCompany_lib;
namespace BusCompany_tests
{
    public class BusFleetTests
    {
        // két busz, az "A" megállót mindkettő érinti
        private static BusFleet CreateFleet()
        {
            Bus small = new Bus("kicsi", 10, new List<string> { "A", "B" });
            Bus big = new Bus("nagy", 20, new List<string> { "A", "C" });
            return new BusFleet(new List<Bus> { small, big });
        }

        [Test]
        public void FleetBusesNull()
        {
            Assert.Throws<ArgumentNullException>(() => new BusFleet(null!));
        }

        [Test]
        public void FleetWithoutBuses()
        {
            Assert.Throws<ArgumentException>(() => new BusFleet(new List<Bus>()));
        }

        [Test]
        public void FleetBusIdDuplicated()
        {
            Bus first = new Bus("busz1", 10, new List<string> { "A" });
            Bus second = new Bus("busz1", 20, new List<string> { "B" });

            Assert.Throws<ArgumentException>(() => new BusFleet(new List<Bus> { first, second }));
        }

        [Test]
        public void FleetWithOneBus()
        {
            Bus bus = new Bus("busz1", 10, new List<string> { "A" });

            Assert.DoesNotThrow(() => new BusFleet(new List<Bus> { bus }));
        }

        [Test]
        public void ServeNextStopReturnsBoardedAndLeftBehind()
        {
            BusFleet fleet = CreateFleet();

            (int boarded, int leftBehind) = fleet.ServeNextStop("kicsi", 0, 15);

            Assert.That(boarded, Is.EqualTo(10));
            Assert.That(leftBehind, Is.EqualTo(5));
        }

        [Test]
        public void ServeNextStopUnknownBus()
        {
            BusFleet fleet = CreateFleet();

            Assert.Throws<ArgumentException>(() => fleet.ServeNextStop("nincs", 0, 1));
        }

        [Test]
        public void ServeNextStopInvalidPassengers()
        {
            BusFleet fleet = CreateFleet();

            Assert.Throws<ArgumentOutOfRangeException>(() => fleet.ServeNextStop("kicsi", 5, 0));
            Assert.That(fleet.GetAlightedAt("A"), Is.EqualTo(0));
            Assert.That(fleet.GetBoardedAt("A"), Is.EqualTo(0));
        }

        [Test]
        public void BusesRunIndependently()
        {
            BusFleet fleet = CreateFleet();
            fleet.ServeNextStop("kicsi", 0, 3);

            fleet.ServeNextStop("nagy", 0, 5);

            Assert.That(fleet.GetBoardedAt("A"), Is.EqualTo(8));
            Assert.That(fleet.GetBoardedAt("B"), Is.EqualTo(0));
            Assert.That(fleet.GetBoardedAt("C"), Is.EqualTo(0));
        }

        [Test]
        public void BoardedAtStopWithoutVisit()
        {
            BusFleet fleet = CreateFleet();

            Assert.That(fleet.GetBoardedAt("B"), Is.EqualTo(0));
        }

        [Test]
        public void AlightedAtStopWithoutVisit()
        {
            BusFleet fleet = CreateFleet();

            Assert.That(fleet.GetAlightedAt("C"), Is.EqualTo(0));
        }

        [Test]
        public void BoardedAtStopSharedByMoreBuses()
        {
            BusFleet fleet = CreateFleet();

            fleet.ServeNextStop("kicsi", 0, 5);
            fleet.ServeNextStop("nagy", 0, 7);

            Assert.That(fleet.GetBoardedAt("A"), Is.EqualTo(12));
        }

        [Test]
        public void BoardedAtStopDoesNotCountPassengersLeftBehind()
        {
            BusFleet fleet = CreateFleet();

            fleet.ServeNextStop("kicsi", 0, 25);

            Assert.That(fleet.GetBoardedAt("A"), Is.EqualTo(10));
        }

        [Test]
        public void AlightedAtStop()
        {
            BusFleet fleet = CreateFleet();
            fleet.ServeNextStop("kicsi", 0, 8);

            fleet.ServeNextStop("kicsi", 3, 0);

            Assert.That(fleet.GetAlightedAt("B"), Is.EqualTo(3));
            Assert.That(fleet.GetAlightedAt("A"), Is.EqualTo(0));
        }

        [Test]
        public void StopStatisticsAddUpOverMoreVisits()
        {
            BusFleet fleet = CreateFleet();

            fleet.ServeNextStop("kicsi", 0, 4);
            fleet.ServeNextStop("kicsi", 2, 1);
            fleet.ServeNextStop("kicsi", 0, 2);

            Assert.That(fleet.GetBoardedAt("A"), Is.EqualTo(6));
            Assert.That(fleet.GetBoardedAt("B"), Is.EqualTo(1));
            Assert.That(fleet.GetAlightedAt("B"), Is.EqualTo(2));
        }

        [Test]
        public void BoardedAtUnknownStop()
        {
            BusFleet fleet = CreateFleet();

            Assert.Throws<ArgumentException>(() => fleet.GetBoardedAt("nincs"));
        }

        [Test]
        public void AlightedAtUnknownStop()
        {
            BusFleet fleet = CreateFleet();

            Assert.Throws<ArgumentException>(() => fleet.GetAlightedAt("nincs"));
        }

        [Test]
        public void TotalCarriedByBusWithoutTrips()
        {
            BusFleet fleet = CreateFleet();

            Assert.That(fleet.GetTotalCarriedBy("kicsi"), Is.EqualTo(0));
        }

        [Test]
        public void TotalCarriedByEveryBusSeparately()
        {
            BusFleet fleet = CreateFleet();

            fleet.ServeNextStop("kicsi", 0, 5);
            fleet.ServeNextStop("kicsi", 2, 3);
            fleet.ServeNextStop("nagy", 0, 7);

            Assert.That(fleet.GetTotalCarriedBy("kicsi"), Is.EqualTo(8));
            Assert.That(fleet.GetTotalCarriedBy("nagy"), Is.EqualTo(7));
        }

        [Test]
        public void TotalCarriedByUnknownBus()
        {
            BusFleet fleet = CreateFleet();

            Assert.Throws<ArgumentException>(() => fleet.GetTotalCarriedBy("nincs"));
        }

        [Test]
        public void EndDayDiscardsTheDailyData()
        {
            BusFleet fleet = CreateFleet();
            fleet.ServeNextStop("kicsi", 0, 5);
            fleet.ServeNextStop("kicsi", 2, 0);
            fleet.ServeNextStop("nagy", 0, 7);

            fleet.EndDay();

            Assert.That(fleet.GetBoardedAt("A"), Is.EqualTo(0));
            Assert.That(fleet.GetAlightedAt("B"), Is.EqualTo(0));
            Assert.That(fleet.GetTotalCarriedBy("kicsi"), Is.EqualTo(0));
            Assert.That(fleet.GetTotalCarriedBy("nagy"), Is.EqualTo(0));
        }

        [Test]
        public void EndDayStopsAreStillKnown()
        {
            BusFleet fleet = CreateFleet();

            fleet.EndDay();

            Assert.That(fleet.GetBoardedAt("A"), Is.EqualTo(0));
            Assert.That(fleet.GetBoardedAt("B"), Is.EqualTo(0));
            Assert.That(fleet.GetBoardedAt("C"), Is.EqualTo(0));
        }

        [Test]
        public void BusesStartTheNextDayEmptyFromTheFirstStop()
        {
            BusFleet fleet = CreateFleet();
            fleet.ServeNextStop("kicsi", 0, 8);
            fleet.EndDay();

            (int boarded, int leftBehind) = fleet.ServeNextStop("kicsi", 0, 10);

            Assert.That(boarded, Is.EqualTo(10));
            Assert.That(leftBehind, Is.EqualTo(0));
            Assert.That(fleet.GetBoardedAt("A"), Is.EqualTo(10));
            Assert.That(fleet.GetBoardedAt("B"), Is.EqualTo(0));
        }
    }
}
