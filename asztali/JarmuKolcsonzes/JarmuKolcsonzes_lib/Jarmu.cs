
namespace JarmuKolcsonzes_lib
{
    public abstract class Jarmu : IJarmuBerles
    {
        public int SzemelyekSzama { get; init; }

        public double Rakter { get; init; }
        public string Rendszam { get; init; }
        public string Tipus { get; init; }
        public IEnumerable<double> RakterMeret { get; init; }
        private bool[] elerhetoseg = new bool[31];
        public Jarmu(string rendszam, string tipus,
            double[] rakter, int szallithatoSzemelyekSzama)
        {
            Rendszam = rendszam;
            Tipus = tipus;
            Rakter = rakter[0] * rakter[1] * rakter[2];
            elerhetoseg.All(x => x = true);
            SzemelyekSzama = szallithatoSzemelyekSzama;
        }

        public bool this[int nap]
        {
            get
            {
                try
                {
                    return elerhetoseg[nap - 1];
                }
                catch
                {
                    throw new HibasIntervallumException();
                }
            }
        }

        public bool Kolcsonzes(int elso, int utolso)
        {
            if (elso < 1 || utolso > 31 || elso > utolso)
            {
                throw new HibasIntervallumException();
            }

            bool kolcsonozheto = true;

            for (int i = elso; elso <= utolso; i++)
            {
                if (elerhetoseg[i - 1] == false)
                {
                    kolcsonozheto = false; 
                    break;
                }
            }

            if (kolcsonozheto)
            {
                for (int i = elso; elso <= utolso; i++)
                {
                    elerhetoseg[i - 1] = false;
                    return true;
                }
            }
            return false;

        }
        public abstract int FizetendoAr(int napok);

        public IEnumerable<int> KolcsonozhetoNapok() => elerhetoseg.Select((value, index) => new { value, index })
            .Where(x => x.value).Select(x => x.index + 1);
        public override string ToString()
        {
            return $"Rendszám: {Rendszam}, Tipus: {Tipus} Szállítható személyek száma: {SzemelyekSzama}, " +
                $"Rakter: {Rakter}, Kölcsönözhető: {string.Join(", ", KolcsonozhetoNapok())}";
        }
    }
}
