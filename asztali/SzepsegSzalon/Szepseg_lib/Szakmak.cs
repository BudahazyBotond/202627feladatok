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
        public int Mennyiseg => _list.Count();
        public Szakma this[string nev]
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
        public IEnumerable<string> OsszSzakma()
        {
            return _list.Select(x => x.Nev) == null?["üres"]: _list.Select(x => x.Nev);
        }
        public List<Szakma> SzakmakList => _list;
    }
}
