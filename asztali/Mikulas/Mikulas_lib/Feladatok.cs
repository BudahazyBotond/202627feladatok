using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_lib
{
    public class Feladatok
    {
        readonly List<Feladat> feladatLista;
        public Feladatok()
        {
            feladatLista = new List<Feladat>();
        }

        public static Feladatok operator + (Feladatok eddigiFeladatok, Feladat ujFeladat)
        {
            var ujFeladatLista = new Feladatok();
            ujFeladatLista.feladatLista.AddRange(eddigiFeladatok.feladatLista);
            ujFeladatLista.feladatLista.Add(ujFeladat);
            return ujFeladatLista;
        }

        public IEnumerable<Feladat> FeladatLista => feladatLista; 
        public Dictionary<string, int> FeladatokOsszMennyisege() => feladatLista.GroupBy(x => x.JatekTipus.Megnevezes).ToDictionary(x => x.Key, x => x.Sum(y => y.DarabSzam));
    }
}
