namespace TesztKiertekeles_lib
{
    public class Teszt
    {
        public string? Nev { get; init; }
        public int? Feladat1 { get; init; }
        public int? Feladat2 { get; init; }
        public int? Feladat3 { get; init; }
        public int? Feladat4 { get; init; }
        public int? Feladat5 { get; init; }
        public Teszt(string sor)
        {
            string[]? adatok = sor.Split(';');
            Nev = NullEstring(adatok[0]);
            Feladat1 = NullEint(adatok[1]);
            Feladat2 = NullEint(adatok[2]);
            Feladat3 = NullEint(adatok[3]);
            Feladat4 = NullEint(adatok[4]);
            Feladat5 = NullEint(adatok[5]);
            string? NullEstring(string? adat) => string.IsNullOrEmpty(adat) ? null : adat;
            int? NullEint(string? adat) => string.IsNullOrEmpty(adat) ? null : int.Parse(adat);
        }
        public int? FeladatPontszam(int index) => index switch
        {
            1 => Feladat1,
            2 => Feladat2,
            3 => Feladat3,
            4 => Feladat4,
            5 => Feladat5,
            _ => null
        };
        private int OsszPont => new int?[] { Feladat1, Feladat2, Feladat3, Feladat4, Feladat5 }.Where(x => x.HasValue).Sum(x => x.Value);
        public double szazalek => OsszPont * 100 / 25.0;
        public string eredmeny => szazalek >= 40 ? "sikeres" : "sikertelen";
    }
}
