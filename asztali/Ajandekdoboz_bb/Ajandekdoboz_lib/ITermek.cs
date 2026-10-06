using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_lib
{
    public interface ITermek
    {
        string Nev { get; }
        int Ar { get; }
        TermekTipusok.TermekTipus Tipus { get; }
        public string ExtraTul();

    }
}
