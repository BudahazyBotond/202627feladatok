using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_lib
{
    public sealed class Edesseg : Termek
    {
        public int CukorPer100g { get; private set; }
        public Edesseg(string nev, int ar, int cukorPer100g)
            : base(nev, ar, TermekTipusok.TermekTipus.Edesseg)
        {
            CukorPer100g = cukorPer100g;
        }
        public override string ToString()
        {
            return base.ToString() + " | " + ExtraTul();
        }
        public override string ExtraTul()
        {
            return $" | 100g-ba {CukorPer100g}g cukor";
        }
    }
}
