using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamonkeres_lib
{
    public sealed class Beadando : Szamonkeres
    {
        public enum Tipusok
        {
            Egyéni,
            Csoport
        }
        public Tipusok Tipus { get; init; }
        public Beadando(int pontszam, string tema, string tipus) : base(pontszam, tema)
        {
            if (tipus.ToLower() == "e")
            {
                this.Tipus = Tipusok.Egyéni;
            }
            else if (tipus.ToLower() == "cs")
            {
                this.Tipus = Tipusok.Csoport;
            }
            else
            {
                throw new ArgumentException("Hibás beadandó típus.");
            }
        }
        public override int Jegy(int elertPontszam)
        {
            if (Megfelelt(elertPontszam))
            {
                double elertSzazalek = (double)elertPontszam / Pontszam;
                if (elertSzazalek >= 0.90)
                {
                    return 5;
                }
                else if (elertSzazalek >= 0.75)
                {
                    return 4;
                }
                else if (elertSzazalek >= 0.60)
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
