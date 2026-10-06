using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public class Katalogus
    {
        private readonly List<Alapanyag> alapanyagok =
            new List<Alapanyag>();

        public Katalogus(IEnumerable<Alapanyag> alapanyagok)
        {
            this.alapanyagok = alapanyagok.ToList();
        }
        public Alapanyag? this[string azonosito]
        {
            get
            {
                return alapanyagok.Find(x => x.Azonosito == azonosito);
            }
        }
    }
}
