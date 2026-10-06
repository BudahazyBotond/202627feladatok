using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_lib
{
    public class Kezelesek
    {
        private List<Kezeles> _list;
        public Kezelesek(IEnumerable<Kezeles> kezelesek)
        {
            _list = kezelesek.ToList();
        }
        public Kezeles this[int id]
        {
            get
            {
                if (_list.Find(x => x.KezelesId == id) == null)
                {
                    throw new Exception();
                }
                return _list.Find(x => x.KezelesId == id)!;
            }
        }
    }
}
