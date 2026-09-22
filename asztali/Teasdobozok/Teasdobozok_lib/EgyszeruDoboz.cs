using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_lib
{
    internal sealed class EgyszeruDoboz : TeasDoboz
    {
        internal Filter Filter { get; init; }
        public override int Ar => Filter.Ar*DarabSzam+100;
        public override string Nev => $"{Filter.Tipus} tea";
        internal EgyszeruDoboz(int darabSzam, string azonosito, Filterek osszesElerhetoFilter) : base(darabSzam)
        {
            var filter = osszesElerhetoFilter[azonosito];
            if (filter == null)
            {
                throw new HibasAzonositoException(DarabSzam, new string[] { azonosito });
            }
            Filter = filter;
        }
    }
}
