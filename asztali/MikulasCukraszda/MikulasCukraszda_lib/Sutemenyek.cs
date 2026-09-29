using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_lib
{
    public class Sutemenyek
    {
        private List<Sutemeny> sutemenyek;
        public Sutemenyek(IEnumerable<Sutemeny> sutemenyek)
        {
            this.sutemenyek = sutemenyek.ToList();
        }

        Sutemeny? this[string azonosito]
        {
            get
            {
                return sutemenyek.Find(x=>x.Azonosito == azonosito);
            }
        }
        public IEnumerable<Sutemeny> SutemenyTipusok => sutemenyek.Where(x => !x.Tipus.StartsWith("d")).OrderBy(x=>x.Azonosito);
    }
}
