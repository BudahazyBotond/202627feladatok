namespace Celeb_lib
{
    public class Ember
    {
        public string Nev { get; init; }
        public string Foglalkozas { get; init; }
        public string Nemzetiseg { get; init; }
        public string Vilaghiru { get; init; }
        public string Nem { get; init; }
        public Ember(string adatSor)
        {
            string[] adatResz = adatSor.Split(';');
            Nev = adatResz[0];
            Foglalkozas = adatResz[1];
            Nemzetiseg = adatResz[2];
            Vilaghiru = adatResz[3];
            Nem = adatResz[4];
        }

    }
}
