using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public sealed class Silec : Sporteszkoz
    {
        public Silec(string azonosito, string leiras, int meret)
        :base(azonosito, leiras, meret)
        {
            
        }
        public override int Bevetel(int berlesHossz)
        {
            if (berlesHossz > 7)
            {
                return (int)Math.Round((8000+3000*(berlesHossz-1))*0.9);
            }
            else
            {
                return 8000 + 3000 * (berlesHossz - 1);
            }
        }
        public override string ToString()
        {
            int osszNap = 0;
            foreach (var item in Foglalasok.Berlesek)
            {
                osszNap += item.NapokSzama;
            }
            return $"{Leiras}: {osszNap} nap kölcsönzés, a várható bevétel: {Bevetel(osszNap)} Ft\n{Foglalasok.ToString()}";
        }
    }
}
