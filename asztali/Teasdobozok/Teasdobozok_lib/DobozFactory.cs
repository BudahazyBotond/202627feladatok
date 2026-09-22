using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_lib
{
    public static class DobozFactory
    {
        public static TeasDoboz Factory(string sor, Filterek filterek)
        {
            string[] mezok = sor.Split(';');
            if (mezok.Count() == 2)
            {
                return new EgyszeruDoboz(int.Parse(mezok[0]), mezok[1], filterek);
            }
            else
            {
                ValogatasDoboz doboz = new ValogatasDoboz(int.Parse(mezok[0]), filterek);
                foreach (var azonosito in mezok.Skip(1))
                {
                    if (filterek[azonosito] == null)
                    {
                        throw new HibasAzonositoException(doboz.DarabSzam, new string[] { azonosito });
                    }
                    doboz += azonosito;
                }
                return doboz;
            }
        }
    }
}
