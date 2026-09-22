using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_lib
{
    internal sealed class ValogatasDoboz : TeasDoboz
    {
        private Filterek filterek;
        private IEnumerable<string> filterAzonositok = new List<string>();
        public override string Nev
        {
            get
            {
                return $"Válogatás tea ({FilterTipusokString})";
            }
        }
        public override int Ar
        {
            get
            {
                if (filterAzonositok == null)
                {
                    return 0;
                }
                return (filterAzonositok.Sum(x => filterek[x]!.Ar)/filterek.Count)*DarabSzam + 100;
            }
        }

        internal ValogatasDoboz(int darabSzam, Filterek filterek) : base(darabSzam)
        {
            this.filterek = filterek;
        }

        public static ValogatasDoboz operator +(ValogatasDoboz doboz, string filterId)
        {
            if (doboz.filterek[filterId] == null)
            {
                throw new HibasAzonositoException(doboz.DarabSzam, (string[])doboz.filterAzonositok);
            }
            ((List<string>)doboz.filterAzonositok).Add(filterId);
            return doboz;
        }
        public string FilterTipusokString
        {
            get
            {
                return string.Join(", ", filterAzonositok.Select(x => filterek[x].Tipus).Distinct());
            }
        }
    }
}
