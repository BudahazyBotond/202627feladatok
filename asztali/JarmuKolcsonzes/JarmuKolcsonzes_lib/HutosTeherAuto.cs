using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzes_lib
{
    public sealed class HutosTeherAuto : Jarmu
    {
        private string homersekletTartomany;
        public HutosTeherAuto(string rendszam, string tipus, double[] rakter, int szemelyekSzama, string homersekletTartomany)
            : base(rendszam, tipus, rakter, szemelyekSzama)
        {
            this.homersekletTartomany = homersekletTartomany;
        }
        public override int FizetendoAr(int napokSzama)
        {
            if (napokSzama <= 0)
            {
                return 0;
            }
            else if (napokSzama <= 3)
            {
                return napokSzama * 19900;
            }
            else if (napokSzama <= 7)
            {
                return napokSzama * 18900;
            }
            else
            {
                return napokSzama * 17900;
            }
        }
        public override string ToString()
        {
            return $"Rendszám: {Rendszam}, Tipus: {Tipus} Szállítható személyek száma: {SzemelyekSzama}, " +
                $"Rakter: {Rakter}, Hőmérséklet tartomány: {homersekletTartomany} C° Kölcsönözhető: {string.Join(", ", KolcsonozhetoNapok())}";
        }

    }
}
