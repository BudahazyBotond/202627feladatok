using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_lib
{
    public sealed class FustoltHus : Termek
    {
        public string FajtaMinoseg { get; private set; }
        public FustoltHus(string nev, int ar, string fajtaMinoseg)
            : base(nev, ar, TermekTipusok.TermekTipus.FustoltHus)
        {
            FajtaMinoseg = fajtaMinoseg;
        }
        public override string ToString()
        {
            return base.ToString() + " | " + ExtraTul();
        }
        public override string ExtraTul()
        {
            return $" | Fajta/minőség: {FajtaMinoseg}";
        }
    }
}
