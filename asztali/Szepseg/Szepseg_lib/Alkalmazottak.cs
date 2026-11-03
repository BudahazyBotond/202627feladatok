using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szepseg_lib
{
    public class Alkalmazottak
    {
        public List<Alkalmazott> _list = new();
        public Alkalmazottak(IEnumerable<Alkalmazott> alkalmazottak)
        {
            _list = alkalmazottak.ToList();
        }
        public Alkalmazott this[string nev]
        {
            get
            {
                return _list.Where(x => x.Nev == nev).First();
            }
        }
        public string[] Nevek(int[] ids)
        {
            List<Alkalmazott> alk = new();
            foreach (int id in ids) { 
                alk.Add(_list.Where(x => x.AlkalmazottId == id).First());
            }
            return alk.Select(x => x.Nev).ToArray();
        }
    }
}
