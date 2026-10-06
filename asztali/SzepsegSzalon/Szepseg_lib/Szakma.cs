using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
