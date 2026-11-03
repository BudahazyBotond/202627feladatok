using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szepseg_lib
{
    public class Vendeg
    {
        public int VendegId { get; init; }
        public string Nev { get; init; }
        public string Cim { get; init; }
        public string Telefon { get; init; }
        public Vendeg(int vendegId, string nev, string cim, string telefon)
        {
            VendegId = vendegId;
            Nev = nev;
            Cim = cim;
            Telefon = telefon;
        }
    }
}
