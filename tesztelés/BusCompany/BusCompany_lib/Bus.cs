namespace BusCompany_lib
{
    public class Bus
    {
        private int _capacity;
        private List<string> _stops;
        private int _nextStopIndex;
        public string Id { get; init; }
        public int Capacity
        {
            get => _capacity;
            init
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _capacity = value;
            }
        }
        public int Passengers { get; private set; }
        public int TotalCarried { get; private set; }
        public int FreeSeats => Capacity - Passengers;
        public IReadOnlyList<string> Stops => _stops.AsReadOnly();
        public string NextStop => _stops[_nextStopIndex];

        public Bus(string id, int capacity, IEnumerable<string> stops)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException();
            }
            Id = id;
            Capacity = capacity;
            _stops = new List<string>(stops);
            if (_stops.Count == 0 || _stops.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException();
            }
        }

        // a busz a következő megállóba ér, visszaadja hányan szálltak fel és hányan maradtak lent
        public (int boarded, int leftBehind) ServeNextStop(int alighting, int waiting)
        {
            if (alighting < 0 || alighting > Passengers || waiting < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Passengers -= alighting; // először mindenki leszáll, aki le akar
            int boarded = Math.Min(waiting, FreeSeats);
            Passengers += boarded;
            TotalCarried += boarded;
            _nextStopIndex = (_nextStopIndex + 1) % _stops.Count; // az utolsó megálló után újra az első jön
            return (boarded, waiting - boarded);
        }

        // nap végén a busz üres és az útvonal elejéről indul
        public void ResetDay()
        {
            Passengers = 0;
            TotalCarried = 0;
            _nextStopIndex = 0;
        }
    }
}
