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
        public int Mennyiseg => _list.Count();
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
        public Alkalmazott this[string nev]
        {
            get
            {
                if (_list.Find(x => x.Nev == nev) == null)
                {
                    throw new Exception();
                }
                return _list.Find(x => x.Nev == nev)!;
            }
        }


        public Alkalmazottak SzakmaSzerint(int szakmaId)
        {
            return new Alkalmazottak(_list.Where(x => x.SzakmaId == szakmaId));
        }
    }
}
