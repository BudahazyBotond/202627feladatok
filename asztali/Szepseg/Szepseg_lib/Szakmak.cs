using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szepseg_lib
{
    public class Szakmak
    {
        public List<Szakma> _list = new();
        public Szakmak(IEnumerable<Szakma> szakmak)
        {
            _list = szakmak.ToList();
        }
        public Szakma this[int szakmaId]
        {
            get
            {
                return _list.Where(x => x.SzakmaId == szakmaId).First();
            }
        }
    }
}
