using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hataratkeles_lib
{
    public class Hataratkelok
    {
        List<Hataratkelo> hataratkelok = new List<Hataratkelo>();
        public Hataratkelok(string[] file) 
        { 
            foreach (var item in file.Skip(1))
            {
                hataratkelok.Add(new Hataratkelo(item.Split(';')));
            }
        }
        public int Db() => hataratkelok.Count;
        public int VasutAtkelo() => hataratkelok.Count(x => x.AtkeloTipus == "vasúti");
        public IEnumerable<Hataratkelo> MegyeiAtkelo() => hataratkelok.Where(x => x.TelepulesTipus == "megyei jogú város");
        public int Ausztriaba() => hataratkelok.Where(x=>x.TelepulesTipus.EndsWith("város")).Count(x => x.Orszag == "Ausztria");
        public Hataratkelo AbcAusztria() => hataratkelok.Where(x => x.Orszag == "Ausztria").OrderBy(x => x.TelepulesNev).First();
        public IEnumerable<string> Orszagok()=> hataratkelok.Select(x => x.Orszag).Distinct().OrderBy(x => x);
        public IEnumerable<string> AbcDuplaAtkelo() => hataratkelok.OrderBy(x => x.TelepulesNev).GroupBy(x => x.TelepulesNev).Where(x => x.DistinctBy(y => y.AtkeloTipus).Count() >= 2).Select(x => x.Key);
        public Dictionary<string, int> OrszagAtkelok() => hataratkelok.GroupBy(x => x.Orszag).ToDictionary(x => x.Key, y => y.Count());
        public IEnumerable<Hataratkelo> LegtobbAtkelo(string megye) => hataratkelok.Where(x => x.Megye == megye);
    }
}
