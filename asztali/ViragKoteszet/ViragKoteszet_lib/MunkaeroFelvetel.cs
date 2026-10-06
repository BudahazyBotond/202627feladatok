using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public static class MunkaeroFelvetel
    {
        public static Dolgozo MunkaeroKeszites(string fajlSor)
        {
            string[] adatok = fajlSor.Split(';');
            try
            {
                switch (adatok[2])
                {
                    case "gy":
                        List<int> azonositok = new List<int>();
                        for (int i = 3; i < adatok.Length; i++)
                        {
                            azonositok.Add(int.Parse(adatok[i]));
                        }
                        return new Gyakornok(
                            int.Parse(adatok[0]),
                            adatok[1],
                            azonositok
                            ); 
                    case "v":
                        return new ViragKoto(
                            int.Parse(adatok[0]),
                            adatok[1]
                            );
                    default:
                        throw new ArgumentException();
                }
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }
}
