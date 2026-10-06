using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public sealed class Snowboard : Sporteszkoz
    {
        public bool Cipovel { get; init; }
        public Snowboard(string azonosito, string leiras, int meret, bool cipovel)
            :base(azonosito, leiras, meret)
        {
            Cipovel = cipovel;
        }

        public override int Bevetel(int berlesHossz)
        {
            if(!Cipovel){
                return 9000 + 3500 * (berlesHossz - 1);
            }
            else
            {
                return 13000 + 4500 * (berlesHossz - 1);
            }
        }

        public override string ToString()
        {
            int osszNap = 0;
            foreach (var item in Foglalasok.Berlesek)
            {
                osszNap += item.NapokSzama;
            }
            string cipo = Cipovel ? "cipővel" : "cipő nélkül";
            return $"{Leiras}, {cipo}: {osszNap} nap kölcsönzés, a várható bevétel: {Bevetel(osszNap)} Ft\n{Foglalasok.ToString()}";
        }
    }
}
