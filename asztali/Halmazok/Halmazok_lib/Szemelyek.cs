using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmazok_lib
{
    public abstract class Szemely
    {
        public string Azonosito { get; set; }
        public string Nev { get; set; }
        public char Tipus { get; set; }
        public Szemely(string azonosito, string nev)
        {
            Azonosito = azonosito;
            Nev = nev;
        }
    }
    public sealed class Tanar : Szemely
    {
        public string Szak { get; set; }
        public Tanar(string azonosito, string nev, string szak) : base(azonosito, nev)
        {
            Tipus = 'T';
            Szak = szak;
        }
    }
    public sealed class Diak : Szemely
    {
        public string Osztaly { get; set; }
        public Diak(string azonosito, string nev, string osztaly) : base(azonosito, nev)
        {
            Tipus = 'D';
            Osztaly = osztaly;
        }
    }
}
