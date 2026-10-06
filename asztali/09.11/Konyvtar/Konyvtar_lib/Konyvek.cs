using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar_lib
{
    public class Konyvek
    {
        readonly List<Konyv> list;
        public Konyvek(string[] file)
        {
            list = new List<Konyv>();
            foreach (var item in file.Skip(1))
            {
                list.Add(new Konyv(item.Split(';')));
            }
            this.list = list;
        }
        public int KonyvAdatai() => list.Count;
        public int KolcsonozhetoKonyvek() => list.Count(x=>x.Kolcsonozhetoseg);
        public int HarryPotterKonyvek() => list.Count(x => x.Cim.Contains("Harry Potter")); 
        public IEnumerable<IGrouping<int,Konyv>>Legtobbkonyv() => list.GroupBy(x => x.KiadasEve).OrderByDescending(x => x.Count()).Take(1);
        public IEnumerable<IGrouping<int, Konyv>> EvesKonyvek() => list.GroupBy(x => x.KiadasEve);
        public IEnumerable<IGrouping<string,Konyv>> SzerzoKonyvek() => list.GroupBy(x=>x.Szerzo).OrderBy(x=>x.Key);
        public string KonyvCim(string cim)
        {
            foreach (var item in list)
            {
                if (item.Cim.ToLower() == cim.ToLower())
                {
                    if (item.Kolcsonozhetoseg) return $"A(z) '{cim}' címü könyv kölcsönözhető.";
                    else return $"A(z) '{cim}' című könyv nem kölcsönözhető.";
                }
            }
            return "Nincs ilyen könyv  a könyvtárban.";
        }
        public IEnumerable<string> Kolcsonozheto() => list.Where(x => x.Kolcsonozhetoseg).OrderBy(x => x.Cim).Select(x => x.Cim).Distinct();
    }
}
