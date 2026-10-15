namespace BusCompany_lib
{
    public class BusFleet
    {
        private Dictionary<string, Bus> _buses = new();
        private Dictionary<string, int> _boardedAtStops = new();
        private Dictionary<string, int> _alightedAtStops = new();

        public BusFleet(IEnumerable<Bus> buses)
        {
            ArgumentNullException.ThrowIfNull(buses);
            foreach (Bus bus in buses)
            {
                if (!_buses.TryAdd(bus.Id, bus)) // az azonosítónak egyedinek kell lennie
                {
                    throw new ArgumentException();
                }
            }
            if (_buses.Count == 0) // legalább egy busz kell
            {
                throw new ArgumentException();
            }
            ClearStopCounters();
        }

        public (int boarded, int leftBehind) ServeNextStop(string busId, int alighting, int waiting)
        {
            Bus bus = FindBus(busId);
            string stop = bus.NextStop;
            (int boarded, int leftBehind) = bus.ServeNextStop(alighting, waiting);
            _boardedAtStops[stop] += boarded;
            _alightedAtStops[stop] += alighting;
            return (boarded, leftBehind);
        }

        public int GetBoardedAt(string stop)
        {
            return GetCount(_boardedAtStops, stop);
        }

        public int GetAlightedAt(string stop)
        {
            return GetCount(_alightedAtStops, stop);
        }

        public int GetTotalCarriedBy(string busId)
        {
            return FindBus(busId).TotalCarried;
        }

        // nap végén eldobjuk az aznapi adatokat
        public void EndDay()
        {
            foreach (Bus bus in _buses.Values)
            {
                bus.ResetDay();
            }
            ClearStopCounters();
        }

        private Bus FindBus(string busId)
        {
            if (!_buses.TryGetValue(busId, out Bus? bus))
            {
                throw new ArgumentException();
            }
            return bus;
        }

        private static int GetCount(Dictionary<string, int> counts, string stop)
        {
            if (!counts.TryGetValue(stop, out int count))
            {
                throw new ArgumentException();
            }
            return count;
        }

        private void ClearStopCounters()
        {
            _boardedAtStops.Clear();
            _alightedAtStops.Clear();
            foreach (string stop in _buses.Values.SelectMany(bus => bus.Stops))
            {
                _boardedAtStops[stop] = 0;
                _alightedAtStops[stop] = 0;
            }
        }
    }
}
