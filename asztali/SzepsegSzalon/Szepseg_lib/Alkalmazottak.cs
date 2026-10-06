using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_lib
{
    public class Alkalmazottak
    {
        private List<Alkalmazott> _list;
        public Alkalmazottak(IEnumerable<Alkalmazott> alkalmazottak)
        {
            _list = alkalmazottak.ToList();
        }
        public Alkalmazott this[int id]
        {
            get
            {
                if (_list.Find(x => x.AlkalmazottId == id) == null)
                {
                    throw new Exception();
                }
                return _list.Find(x => x.AlkalmazottId == id)!;
            }
        }
    }
}
