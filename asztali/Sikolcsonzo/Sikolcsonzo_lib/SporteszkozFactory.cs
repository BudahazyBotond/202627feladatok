using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public class SporteszkozFactory
    {
        public static Sporteszkoz Factory(string line)
        {
            //Tipus;Azonosito;Leiras;Meret;Cipo
            string[] adatok = line.Split(';');
            if (adatok[0] == "L")
            {
                return new Silec(adatok[1], adatok[2], int.Parse(adatok[3]));
            }
            else
            {
                if (adatok.Length == 5)
                {
                    return new Snowboard(adatok[1], adatok[2], int.Parse(adatok[3]),true);
                }
                else
                {
                    return new Snowboard(adatok[1], adatok[2], int.Parse(adatok[3]), false);
                }
            }
        }
    }
}
