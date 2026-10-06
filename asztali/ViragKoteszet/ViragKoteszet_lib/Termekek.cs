using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public class Termekek
    {
        private readonly List<Termek> termekek =
            new List<Termek>();

        public Termekek()
        {
        }
        public override string ToString()
        {
            string szoveg = "";
            foreach (Termek termek in termekek)
            {
               szoveg += termek.ToString() + "\n";
            }
            return szoveg;
        }
        public Termek? this[int id]
        {
            get
            {
                return termekek.Find(x => x.Id == id);
            }
        }
        public void Termekfelvetel(Termek termek)
        {
            termekek.Add(termek);
        }
        public List<Termek> OsszesTermek =>
            termekek;
    }
}
