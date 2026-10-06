using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_lib
{
    public sealed class Bor : Termek
    {
        public double AlkoholSzazalek { get; private set; }
        public Bor(string nev, int ar, double alkoholSzazalek)
            : base(nev, ar, TermekTipusok.TermekTipus.Bor)
        {
            AlkoholSzazalek = alkoholSzazalek;
        }
        public override string ToString()
        {
            return base.ToString() + " | " + ExtraTul();
        }
        public override string ExtraTul()
        {
            return $" | Alkoholtartalom: {AlkoholSzazalek}%";
        }
    }
}
