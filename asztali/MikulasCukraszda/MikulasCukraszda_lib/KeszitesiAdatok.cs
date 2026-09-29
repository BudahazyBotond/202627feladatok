using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_lib
{
    public class KeszitesiAdatok
    {
        private List<KeszitesAdat> adatok = new();
        public IEnumerable<string> ElerhetoKeszitesAzonositok => adatok.Select(x => x.Azonosito).Order().Distinct();
        public KeszitesiAdatok(IEnumerable<KeszitesAdat> adatok)
        {
            this.adatok = adatok.ToList();
        }

        public KeszitesAdat? this[string azonosito]
        {
            get
            {
                return adatok.Find(x=>x.Azonosito == azonosito);
            }
        }

    }
}
