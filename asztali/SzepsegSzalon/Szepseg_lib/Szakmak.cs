using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_lib
{
    public class Szakmak
    {
        private List<Szakma> _list;
        public Szakmak(IEnumerable<Szakma> szakmak)
        {
            _list = szakmak.ToList();
        }
        public Szakma this[int id]
        {
            get
            {
                if (_list.Find(x => x.SzakmaId == id) == null)
                {
                    throw new Exception();
                }
                return _list.Find(x => x.SzakmaId == id)!;
            }
        }
    }
}
