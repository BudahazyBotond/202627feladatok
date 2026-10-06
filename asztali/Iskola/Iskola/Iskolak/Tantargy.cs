using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskolak
{
    public class Tantargy
    {
        public string Nev { get; set; }
        public string Kod { get; set; }

        public Tantargy(string nev, string kod)
        {
            Nev = nev;
            Kod = kod;
        }
    }
}
