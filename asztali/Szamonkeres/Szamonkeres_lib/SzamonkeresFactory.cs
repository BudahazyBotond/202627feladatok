using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamonkeres_lib
{
    public class SzamonkeresFactory
    {
        public Szamonkeres Factory(string fajlSor)
        {
            string[] sor = fajlSor.Split(";");

            if (fajlSor.ToLower() == "d")
            {
                return new Dolgozat(int.Parse(sor[1]), sor[3], int.Parse(sor[2]));
            }
            else if (fajlSor.ToLower() == "b")
            {
                return new Beadando(int.Parse(sor[1]), sor[2], sor[3]);
            }
            else
            {
                throw new ArgumentException("Hibás dolgozat típus");
            }
        }
    }
}
