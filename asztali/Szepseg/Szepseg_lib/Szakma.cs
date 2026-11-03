using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szepseg_lib
{
    public class Szakma
    {
        public int SzakmaId { get; init; }
        public string Nev { get; init; }
        public Szakma(int szakmaId, string nev)
        {
            SzakmaId = szakmaId;
            Nev = nev;
        }
        public override string ToString()
        {
            return Nev;
        }
    }
}
