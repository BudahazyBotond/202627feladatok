using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public class Foglalas
    {
        public List<Berles> Berlesek = new();
        public bool IsEmpty => Berlesek.Count == 0;
        public bool SzabadE(DateOnly elsoNap, int berlesHossz)
        {
            bool szabadE = true;
            foreach(Berles e in Berlesek)
            {
                if((e.BerlesKezdet <= elsoNap && e.BerlesVeg>=elsoNap) || (e.BerlesKezdet <= elsoNap.AddDays(berlesHossz) && e.BerlesVeg >= elsoNap.AddDays(berlesHossz)))
                {
                    szabadE = false;
                    break;
                }
            }
            return szabadE;
        }

        public static Foglalas operator +(Foglalas foglalas, Berles berles)
        {
            if (foglalas.SzabadE(berles.BerlesKezdet, berles.NapokSzama))
            {
                foglalas.Berlesek.Add(berles);
            }
            else
            {
                throw new HibasFoglalasException();
            }
            return foglalas;
        }

        public override string ToString()
        {
            string sb = "";
            foreach(Berles berles in Berlesek.OrderBy(x => x.BerlesKezdet))
            {
                sb += berles.ToString()+"\n";
            }
            return sb[0..^1];
        }
    }
}
