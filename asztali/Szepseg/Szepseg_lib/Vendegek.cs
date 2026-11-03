using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szepseg_lib
{
    public class Vendegek
    {
        public List<Vendeg> _list = new();
        public Vendegek(IEnumerable<Vendeg> vendegek)
        {
            _list = vendegek.ToList();
        }
        public Vendeg? this[string nev]
        {
            get
            {
                return _list.Where(x => x.Nev == nev).FirstOrDefault();
            }
        }
    }
}
