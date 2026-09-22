namespace Teasdobozok_lib
{
    public class Filterek
    {
        private List<Filter> _filterek;
        public Filterek(IEnumerable<Filter> filterek)
        {
            _filterek = filterek.ToList();
        }

        public Filter? this[string azonosito]
        {
            get
            {
                return _filterek.Find(x => x.Azonosito == azonosito);
            }
        }

        internal int Count
        {
            get
            {
                return _filterek.Count();
            }
        }
        public List<string> GyogynovenyFilterek => _filterek.Where(x => x.Gyogytea).OrderBy(x => x.Tipus).Select(x => x.Azonosito).ToList();
    }
}
