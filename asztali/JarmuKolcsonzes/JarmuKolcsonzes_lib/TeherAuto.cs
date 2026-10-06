using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzes_lib
{
    public sealed class TeherAuto : Jarmu
    {
        public TeherAuto(string rendszam, string tipus, double[] rakter, int szemelyekSzama)
            : base(rendszam, tipus, rakter, szemelyekSzama)
        {
        }

        public override int FizetendoAr(int napok)
        {
            if (napok < 1)
            {
                throw new ArgumentException();
            }
            else if (napok > 7)
            {
                return 14900 * napok;
            }
            else if (napok >= 4)
            {
                return 16900 * napok;
            }
            return 17900 * napok;
        }
    }
}
