using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public class Dolgozok
    {
        private readonly List<Dolgozo> dolgozok= 
            new List<Dolgozo>();
        public Dolgozo? this[int id]
        {
            get
            {
                return dolgozok.Find(x => x.Id == id);
            }
        }
        public List<Dolgozo> OsszesDolgozo =>
            dolgozok;
        public int DolgozokSzama =>
            dolgozok.Count;
        public void Dolgozofelvetel(Dolgozo dolgozo)
        {
            dolgozok.Add(dolgozo);
        }
    }
}
