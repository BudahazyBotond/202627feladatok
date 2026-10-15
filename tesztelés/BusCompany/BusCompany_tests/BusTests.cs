using BusCompany_lib;
namespace BusCompany_tests
{
    public class BusTests
    {
        private static Bus CreateBus(int capacity = 10)
        {
            return new Bus("busz1", capacity, new List<string> { "A", "B", "C" });
        }

        [Test]
        public void ValidBus()
        {
            Bus bus = CreateBus(12);

            Assert.That(bus.Id, Is.EqualTo("busz1"));
            Assert.That(bus.Capacity, Is.EqualTo(12));
            Assert.That(bus.Stops, Is.EqualTo(new List<string> { "A", "B", "C" }));
            Assert.That(bus.Passengers, Is.EqualTo(0));
            Assert.That(bus.FreeSeats, Is.EqualTo(12));
            Assert.That(bus.TotalCarried, Is.EqualTo(0));
            Assert.That(bus.NextStop, Is.EqualTo("A"));
        }

        [Test]
        public void BusCapacityZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Bus("busz1", 0, new List<string> { "A" }));
        }

        [Test]
        public void BusCapacityMinus()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Bus("busz1", -1, new List<string> { "A" }));
        }

        [Test]
        public void BusIdEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Bus("", 10, new List<string> { "A" }));
        }

        [Test]
        public void BusIdWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Bus("   ", 10, new List<string> { "A" }));
        }

        [Test]
        public void BusStopsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Bus("busz1", 10, null!));
        }

        [Test]
        public void BusStopsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Bus("busz1", 10, new List<string>()));
        }

        [Test]
        public void BusStopNameEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Bus("busz1", 10, new List<string> { "A", "" }));
        }

        [Test]
        public void StopsAreCopiedFromTheSourceList()
        {
            List<string> stops = new List<string> { "A", "B" };
            Bus bus = new Bus("busz1", 10, stops);

            stops.Add("C");

            Assert.That(bus.Stops, Is.EqualTo(new List<string> { "A", "B" }));
        }

        [Test]
        public void EveryoneFitsOnTheBus()
        {
            Bus bus = CreateBus(10);

            (int boarded, int leftBehind) = bus.ServeNextStop(0, 4);

            Assert.That(boarded, Is.EqualTo(4));
            Assert.That(leftBehind, Is.EqualTo(0));
            Assert.That(bus.Passengers, Is.EqualTo(4));
        }

        [Test]
        public void WaitingAsManyAsFreeSeats()
        {
            Bus bus = CreateBus(10);

            (int boarded, int leftBehind) = bus.ServeNextStop(0, 10);

            Assert.That(boarded, Is.EqualTo(10));
            Assert.That(leftBehind, Is.EqualTo(0));
            Assert.That(bus.FreeSeats, Is.EqualTo(0));
        }

        [Test]
        public void NotEnoughFreeSeats()
        {
            Bus bus = CreateBus(10);

            (int boarded, int leftBehind) = bus.ServeNextStop(0, 15);

            Assert.That(boarded, Is.EqualTo(10));
            Assert.That(leftBehind, Is.EqualTo(5));
            Assert.That(bus.Passengers, Is.EqualTo(10));
        }

        [Test]
        public void FullBusNobodyBoards()
        {
            Bus bus = CreateBus(10);
            bus.ServeNextStop(0, 10);

            (int boarded, int leftBehind) = bus.ServeNextStop(0, 3);

            Assert.That(boarded, Is.EqualTo(0));
            Assert.That(leftBehind, Is.EqualTo(3));
            Assert.That(bus.Passengers, Is.EqualTo(10));
        }

        [Test]
        public void AlightingFreesUpSeatsForBoarding()
        {
            Bus bus = CreateBus(10);
            bus.ServeNextStop(0, 10);

            (int boarded, int leftBehind) = bus.ServeNextStop(6, 8);

            Assert.That(boarded, Is.EqualTo(6));
            Assert.That(leftBehind, Is.EqualTo(2));
            Assert.That(bus.Passengers, Is.EqualTo(10));
        }

        [Test]
        public void EveryoneAlights()
        {
            Bus bus = CreateBus(10);
            bus.ServeNextStop(0, 7);

            bus.ServeNextStop(7, 0);

            Assert.That(bus.Passengers, Is.EqualTo(0));
        }

        [Test]
        public void NobodyAlightsNobodyWaits()
        {
            Bus bus = CreateBus(10);
            bus.ServeNextStop(0, 5);

            (int boarded, int leftBehind) = bus.ServeNextStop(0, 0);

            Assert.That(boarded, Is.EqualTo(0));
            Assert.That(leftBehind, Is.EqualTo(0));
            Assert.That(bus.Passengers, Is.EqualTo(5));
        }

        [Test]
        public void MoreAlightingThanPassengers()
        {
            Bus bus = CreateBus(10);
            bus.ServeNextStop(0, 3);

            Assert.Throws<ArgumentOutOfRangeException>(() => bus.ServeNextStop(4, 0));
            Assert.That(bus.Passengers, Is.EqualTo(3));
            Assert.That(bus.NextStop, Is.EqualTo("B"));
        }

        [Test]
        public void AlightingMinus()
        {
            Bus bus = CreateBus(10);

            Assert.Throws<ArgumentOutOfRangeException>(() => bus.ServeNextStop(-1, 0));
        }

        [Test]
        public void WaitingMinus()
        {
            Bus bus = CreateBus(10);

            Assert.Throws<ArgumentOutOfRangeException>(() => bus.ServeNextStop(0, -1));
            Assert.That(bus.NextStop, Is.EqualTo("A"));
        }

        [Test]
        public void StopsAreServedInOrder()
        {
            Bus bus = CreateBus();

            Assert.That(bus.NextStop, Is.EqualTo("A"));
            bus.ServeNextStop(0, 0);
            Assert.That(bus.NextStop, Is.EqualTo("B"));
            bus.ServeNextStop(0, 0);
            Assert.That(bus.NextStop, Is.EqualTo("C"));
        }

        [Test]
        public void RouteStartsOverAfterTheLastStop()
        {
            Bus bus = CreateBus();

            bus.ServeNextStop(0, 0);
            bus.ServeNextStop(0, 0);
            bus.ServeNextStop(0, 0);

            Assert.That(bus.NextStop, Is.EqualTo("A"));
        }

        [Test]
        public void SingleStopRoute()
        {
            Bus bus = new Bus("busz1", 10, new List<string> { "A" });

            bus.ServeNextStop(0, 1);

            Assert.That(bus.NextStop, Is.EqualTo("A"));
        }

        [Test]
        public void TotalCarriedCountsEveryoneWhoBoarded()
        {
            Bus bus = CreateBus(10);
            bus.ServeNextStop(0, 10);
            bus.ServeNextStop(6, 8);

            Assert.That(bus.TotalCarried, Is.EqualTo(16));
        }

        [Test]
        public void TotalCarriedDoesNotCountPassengersLeftBehind()
        {
            Bus bus = CreateBus(10);

            bus.ServeNextStop(0, 25);

            Assert.That(bus.TotalCarried, Is.EqualTo(10));
        }

        [Test]
        public void ResetDay()
        {
            Bus bus = CreateBus(10);
            bus.ServeNextStop(0, 6);
            bus.ServeNextStop(2, 3);

            bus.ResetDay();

            Assert.That(bus.Passengers, Is.EqualTo(0));
            Assert.That(bus.TotalCarried, Is.EqualTo(0));
            Assert.That(bus.NextStop, Is.EqualTo("A"));
        }
    }
}
