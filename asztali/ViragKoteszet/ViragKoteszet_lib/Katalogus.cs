using System;
using System.Collections.Generic;
using System.Text;

namespace ViragKoteszet_lib
{
    public class Katalogus
    {
        private List<Alapanyag> _alapanyagok { get; } = new List<Alapanyag>();
        public Katalogus(IEnumerable<Alapanyag> alapanyagok)
        {
            foreach(var alapanyag in alapanyagok)
            {
                _alapanyagok.Add(alapanyag);
            }
        }
        public Alapanyag? this[string azonosito]
        {
            get
            {
                if(_alapanyagok.Any(x => x.Azonosito == azonosito))
                {
                    return _alapanyagok.First(x => x.Azonosito == azonosito);
                }
                return null;
            }
        }
    }
}
