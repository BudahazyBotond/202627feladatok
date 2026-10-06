namespace Fizetesek_lib
{
    public class Munkadij
    {
        public string Nev { get; set; }
        public int Osszeg { get; set; }

        public Munkadij(string nev, int osszeg)
        {
            Nev = nev;
            Osszeg = osszeg;
        }
    }
}
