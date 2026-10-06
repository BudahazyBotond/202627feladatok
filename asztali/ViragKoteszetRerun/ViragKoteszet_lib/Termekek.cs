using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    internal class Termekek
    {
        private List<Termek> _termekek {  get; init; }
        public Termekek(IEnumerable<Termek> termekek)
        {
            _termekek = termekek.ToList();
        }

        public Termek? this[string azonosito]
        {
            get
            {
                return _termekek.Find(x =>x.Megnevezes == azonosito);
            }
        }
    }
}
