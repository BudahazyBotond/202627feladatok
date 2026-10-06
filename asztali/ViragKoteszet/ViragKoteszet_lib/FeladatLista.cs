using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public class FeladatLista
    {
        public List<Termek> feladatok = new List<Termek>();
        public FeladatLista()
        {
        }
        public static FeladatLista operator
            +(FeladatLista Feladatlista, Termek feladat)
        {
            Feladatlista.feladatok.Add(feladat);
            return Feladatlista;
        }
        public List<Termek> FeladatokListaja => feladatok;
        public int FeladatokElkeszetesiIdeje =>
            feladatok.Sum(x=> x.ElkeszitesiIdo);
    }
}
