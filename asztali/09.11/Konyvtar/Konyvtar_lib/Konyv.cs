namespace Konyvtar_lib
{
    public class Konyv
    {
        public string Cim { get; init; }
        public string Szerzo { get; init; }
        public int KiadasEve { get; init; }
        public bool Kolcsonozhetoseg { get; init; }
        public Konyv(string[] sor)
        {
            Cim = sor[0];
            Szerzo = sor[1];
            KiadasEve = int.Parse(sor[2]);
            if (sor[3] == "igen")
            {
                Kolcsonozhetoseg = true;
            }
        }
    }
}
