using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskolak
{
    public class Diak
    {
        public string Nev { get; set; }
        public int Azonosito { get; set; }
        public Dictionary<Tantargy, int> Jegyek { get; private set; }

        public Diak(string nev, int azonosito)
        {
            Nev = nev;
            Azonosito = azonosito;
            Jegyek = new Dictionary<Tantargy, int>();
        }

        public void JegyHozzaad(Tantargy tantargy, int jegy)
        {
            Jegyek[tantargy] = jegy;
        }
    }

}
