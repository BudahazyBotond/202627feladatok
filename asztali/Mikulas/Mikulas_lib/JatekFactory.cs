using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_lib
{
    public class JatekFactory
    {
        public static Jatek Factory(string adatsor, GyartasAdatok gyartas)
        {
            string[] adatok = adatsor.Split(';');
            return adatok[1] switch
            {
                "i" => new InteraktivJatek(adatok[0], adatok[1], adatok[2], gyartas, adatok.Skip(3)),
                _ => new EgyszeruJatek(adatok[0], adatok[1], adatok[2], gyartas)
            };
        }
    }
}
