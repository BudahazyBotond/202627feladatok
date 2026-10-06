using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Autoverseny_lib.KategoriakEnum;

namespace Autoverseny_lib
{
    internal class Versenyzo
    {
        public string Nev { get; set; }
        public Kategoria Kategoria { get; set; }
        public int Benzin { get; set; }
        public int Helyezes { get; set; }
        public bool Kiesett { get; set; }
        public int Korok { get; set; }

        public Versenyzo(string nev, Kategoria kategoria, int helyezes)
        {
            Nev = nev;
            Kategoria = kategoria;
            Benzin = 100;
            Helyezes = helyezes;
            Kiesett = false;
            Korok = 0;
        }

        public override string ToString()
        {
            return $"{Nev} (B:{Benzin}%)";
        }
    }
}
