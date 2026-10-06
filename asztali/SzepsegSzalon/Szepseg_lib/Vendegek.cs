using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_lib
{
    public class Vendegek
    {
        private List<Vendeg> _list;
        public Vendegek(IEnumerable<Vendeg> list)
        {
            _list = list.ToList();
        }

        public Vendeg this[int id]
        {
            get
            {
                if(_list.Find(x => x.VendegId == id) == null)
                {
                    throw new Exception();
                }
                return _list.Find(x => x.VendegId == id)!;
            }
        }
    }
}
