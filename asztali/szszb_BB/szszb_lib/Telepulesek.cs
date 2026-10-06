using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szszb_lib
{
    public class Telepulesek
    {
        readonly List<Telepules> telepulesek = new List<Telepules>();
        public Telepulesek(string fajlNev)
        {
            string[] fajl = File.ReadAllLines(fajlNev);
            foreach (var sor in fajl.Skip(1))
            {
                telepulesek.Add(new Telepules(sor.Split(';')));
            }
            telepulesek = telepulesek.OrderBy(x => x.nev).ToList();
        }
        public int Darab() => telepulesek.Count;
        public double AtlagSzatmar() => Math.Round(telepulesek.Average(x => x.terulet),1);
        public string[] Tersegek() => telepulesek.OrderBy(x => x.terseg).Select(x => x.terseg).Distinct().ToArray();
        public Telepules? KeresLegnagyobb(string terseg) => telepulesek.Where(x => x.terseg.ToLower() == terseg.ToLower()).OrderByDescending(x => x.nepsuruseg).FirstOrDefault();
        public IGrouping<string, Telepules>[] RangszerintiVarosok() => telepulesek.GroupBy(x => x.rang).ToArray();
        public string ToString(Telepules terseg)
        {
            return $"\tTelepülésnév: {terseg.nev}\n\tRang: {terseg.rang}\n\tNépsűrűség: {terseg.nepsuruseg.ToString("0.00")} fő/km2";
        }
    }
}
