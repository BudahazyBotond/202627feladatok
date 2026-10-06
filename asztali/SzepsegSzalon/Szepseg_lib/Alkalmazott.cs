using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_lib
{
    public class Alkalmazott
    {
        public int AlkalmazottId { get; init; }
        public string Nev { get; init; }
        public int SzakmaId { get; init; }
        public string Telefon { get; init; }
        public Alkalmazott(int alkalmazottId, string nev, int szakmaId, string tel)
        {
            AlkalmazottId = alkalmazottId;
            Nev = nev;
            SzakmaId = szakmaId;
            Telefon = tel;
        }
    }
}
