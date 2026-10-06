using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_lib
{
    public abstract class Termek : ITermek
    {
        public string Nev { get; private set; }
        public int Ar { get; private set; }
        public TermekTipusok.TermekTipus Tipus { get; private set; }
        public Termek(string nev, int ar, TermekTipusok.TermekTipus tipus)
        {
            Nev = nev;
            Ar = ar;
            Tipus = tipus;
        }
        public override string ToString()
        {
            return $"{Nev} - {Ar} Ft - {Tipus}";
        }
        public virtual string ExtraTul()
        {
            return string.Empty;
        }
    }
}
