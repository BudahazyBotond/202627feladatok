using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    internal class Katalogus
    {
        private List<Alapanyag> _katalogus { get; init; }
        public Katalogus(IEnumerable<Alapanyag> alapanyagok)
        {
            _katalogus = alapanyagok.ToList();
        }

        public Alapanyag? this[string azonosito]
        {
            get 
            { 
                return _katalogus.Find(x=>x.Azonosito == azonosito); 
            }
        }
    }
}
