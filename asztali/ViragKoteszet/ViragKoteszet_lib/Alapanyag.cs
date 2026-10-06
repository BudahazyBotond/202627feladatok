namespace ViragKoteszet_lib
{
    public class Alapanyag
    {
        public Alapanyag(string azonosito, string nev, int ar, int elkeszitesiIdo)
        {
            Azonosito = azonosito;
            Nev = nev;
            Ar = ar;
            ElkeszitesiIdo = elkeszitesiIdo;
        }

        public string Azonosito { get; init; }
        public string Nev { get; init; }
        public int Ar { get; init; }
        public int ElkeszitesiIdo { get; init; }

    }
}
