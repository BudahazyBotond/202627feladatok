using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzes_lib
{
    public static class JarmuFactory
    {
        public static Jarmu Factory(string adatsor)
        {
            string[] adatok = adatsor.Split(';');

            if (adatok.Length < 6)
            {
                throw new ArgumentException("Hibás adatsor formátum!");
            }

            string rendszam = adatok[0];
            string tipus = adatok[1];
            double[] rakterMeret = new double[3];
            rakterMeret[0] = Convert.ToDouble(adatok[2]);
            rakterMeret[1] = Convert.ToDouble(adatok[3]);
            rakterMeret[2] = Convert.ToDouble(adatok[4]);
            int szemelyekSzama = Convert.ToInt32(adatok[5]);

            if (adatok.Length == 7)
            {
                string homerseklet = adatok[6];
                return new HutosTeherAuto(rendszam, tipus, rakterMeret, szemelyekSzama, homerseklet);
            }
            else
            {
                return new TeherAuto(rendszam, tipus, rakterMeret, szemelyekSzama);
            }
        }
    }
}
