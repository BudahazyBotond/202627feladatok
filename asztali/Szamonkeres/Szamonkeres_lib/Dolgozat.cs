using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamonkeres_lib
{
    public class Dolgozat : Szamonkeres
    {
        public int Szazalek { get; init; }
        public Dolgozat(int pontszam, string tema, int szazalek) : base(pontszam, tema)
        {
            this.Szazalek = szazalek;
        }
        public override int Jegy(int elertPontszam)
        {
            if (Megfelelt(elertPontszam))
            {
                double elertSzazalek = (double)elertPontszam / Pontszam;
                if (elertSzazalek >= 0.85)
                {
                    return 5;
                }
                else if (elertSzazalek >= 0.70)
                {
                    return 4;
                }
                else if (elertSzazalek >= 0.55)
                {
                    return 3;
                }
                else
                {
                    return 2;
                }
            }
            return 1;
        }
    }
}
