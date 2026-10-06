using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public class Sporteszkoz
    {
        public string Azonosito { get; init; }
        public string Leiras { get; init; }
        public int Meret { get; init; }
        public Foglalas Foglalasok { get; set; }
        public Sporteszkoz(string azonosito, string leiras, int meret)
        {
            Azonosito = azonosito;
            Leiras = leiras;
            Meret = meret;
            Foglalasok = new Foglalas();
        }
        public bool UjBerles(Berles berles)
        {
            try
            {
                Foglalasok += berles;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public virtual int Bevetel(int berlesHossz) => throw new NotImplementedException();

        public bool this[DateOnly nap]
        {
            get
            {
                return Foglalasok.SzabadE(nap,0);
            }
        }
            

    }
}
