namespace Halmazok_lib
{
    public class Halmaz<T>
    {
        public HashSet<T> Elemei { get; private set; }
        public Halmaz()
        {
            Elemei = new HashSet<T>();
        }
        public Halmaz(IEnumerable<T> elemek)
        {
            Elemei = new HashSet<T>(elemek);
        }
        public int ElemMennyiseg => Elemei.Count;
        public bool Tartalmaz(T elem) => Elemei.Contains(elem);
        public void Hozzaad(T elem) => Elemei.Add(elem);
        public void Torol(T elem) => Elemei.Remove(elem);
        public IEnumerable<T> Elemek => Elemei;
        public static Halmaz<T> operator +(Halmaz<T> a, Halmaz<T> b) => new Halmaz<T>(a.Elemei.Union(b.Elemei));
        public static Halmaz<T> operator *(Halmaz<T> a, Halmaz<T> b) => new Halmaz<T>(a.Elemei.Intersect(b.Elemei));
        public static Halmaz<T> operator -(Halmaz<T> a, Halmaz<T> b) => new Halmaz<T>(a.Elemei.Except(b.Elemei));
        public override string ToString() => "Halmaz tartalma: " + string.Join(", ", Elemei);

    }
}
