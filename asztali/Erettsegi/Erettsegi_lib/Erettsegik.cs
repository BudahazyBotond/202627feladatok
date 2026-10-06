using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erettsegi_lib
{
    public class Erettsegik
    {
        public List<Tanar> tanarLista = new List<Tanar>();
        public List<Vizsgazo> vizsgazoLista = new List<Vizsgazo>();
        public List<Vizsga> vizsgaLista = new List<Vizsga>();

        public Erettsegik(string tanarF, string vizsgaF, string vizsgazoF)
        {
            string[] tanarFile = File.ReadAllLines(tanarF);
            string[] vizsgaFile = File.ReadAllLines(vizsgaF);
            string[] vizsgazoFile = File.ReadAllLines(vizsgazoF);
            foreach (string sor in tanarFile.Skip(1))
            {
                string[] adatok = sor.Replace("\"","").Split("\t");
                Tanar tanar = new Tanar(adatok[0], adatok[1]);
                tanarLista!.Add(tanar);
            }
            foreach (string sor in vizsgaFile.Skip(1))
            {
                string[] adatok = sor.Replace("\"", "").Split("\t");
                vizsgaLista!.Add(new Vizsga(adatok[0], adatok[1], adatok[2], adatok[3], adatok[4]));
            }
            foreach (string sor in vizsgazoFile.Skip(1))
            {
                string[] adatok = sor.Replace("\"", "").Split("\t");
                vizsgazoLista!.Add(new Vizsgazo(adatok[0], adatok[1], int.Parse(adatok[2]), adatok[3]));
            }
        }

        public int ListDb(string list)
        {
            switch(list)
            {
                case "tanár": return tanarLista.DistinctBy(x=>x.Nev).Count();
                case "vizsgázó": return vizsgazoLista.DistinctBy(x => x.Nev).Count();
                case "vizsga": return vizsgaLista.Count;
                default: return 0;
            }
        }
        public (double,int) OsztalySzazalek(string osztaly)
        {
            try
            {
            return (Math.Round(vizsgazoLista.Where(x=> x.TeljesOsztaly.ToUpper() == osztaly.ToUpper()).DistinctBy(x => x.Nev).Count() / (double) vizsgazoLista.DistinctBy(x => x.Nev).Count(),2)*100,
            vizsgazoLista.Where(x => x.TeljesOsztaly.ToUpper() == osztaly.ToUpper()).DistinctBy(x => x.Nev).Count());
            }
            catch (Exception ex)
            {
                return (0, 0);
            }

        }
        public Dictionary<string,int> TargyankentDb() => vizsgaLista.GroupBy(x => x.Vizsgatargy).ToDictionary(g=>g.Key, g=>g.Count());
        public string[] TanuloVizsgatargyai(string tanulo) => vizsgazoLista.Join(vizsgaLista, x => x.Id, y => y.VizsgazoId,(x,y) => new { Vizsgazo = x, Vizsga = y}).Where(x=>x.Vizsgazo.Nev == tanulo).Select(X=>X.Vizsga.Vizsgatargy).Distinct().ToArray();
    }
}
