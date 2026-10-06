using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizetesek_lib
{
    public class Kifizetes
    {
        private List<Munkadij> munkalista;
        public Kifizetes(string fajlNev)
        {
            munkalista = new List<Munkadij>();
            foreach (string sor in File.ReadAllLines(fajlNev))
            {
                string[] adatok = sor.Split(';');
                if (adatok.Length == 2)
                {
                    if (int.TryParse(adatok[1], out int osszeg))
                    {
                        munkalista.Add(new Munkadij(adatok[0], osszeg));
                    }
                }
            }
        }
        public int this[string nev]
        {
            get
            {
                return munkalista.Where(m => m.Nev == nev).Sum(m => m.Osszeg);
            }
        }
        private Dictionary<string, int> KerekitettFizetesek()
        {
            var osszesites = munkalista.GroupBy(m => m.Nev)
                                      .ToDictionary(
                                          g => g.Key,
                                          g => this[g.Key] 
                                      );
            var kerekitek = new Dictionary<string, int>();
            foreach (var par in osszesites)
            {
                int kerekített = (int)(Math.Round((double)par.Value / 100) * 100);
                kerekitek.Add(par.Key, kerekített);
            }
            return kerekitek;
        }
        public List<string> HarmadikFeladat()
        {
            var fizetesek = KerekitettFizetesek();
            var rendezettFizetesek = fizetesek.OrderBy(p => p.Key);
            List<string> lista = new();
            foreach (var par in rendezettFizetesek)
            {
                lista.Add($"{par.Key} havi fizetése: {par.Value} Ft.");
            }
            return lista;
        }
        public Dictionary<int, int> Címletezes(int osszeg)
        {
            int[] címletek = { 20000, 10000, 5000, 2000, 1000, 500, 200, 100 };
            var szuksegesCímletek = new Dictionary<int, int>();
            int maradek = osszeg;

            foreach (int címlet in címletek)
            {
                if (maradek >= címlet)
                {
                    int db = maradek / címlet;
                    szuksegesCímletek.Add(címlet, db);
                    maradek %= címlet;
                }
                if (maradek == 0) break;
            }
            return szuksegesCímletek;
        }
        public List<string> OtodikFeladat()
        {
            var fizetesek = KerekitettFizetesek();
            var osszesCimlet = new Dictionary<int, int>();
            foreach (var par in fizetesek)
            {
                var dolgozoCimletei = Címletezes(par.Value);
                foreach (var címletPar in dolgozoCimletei)
                {
                    if (osszesCimlet.ContainsKey(címletPar.Key))
                    {
                        osszesCimlet[címletPar.Key] += címletPar.Value;
                    }
                    else
                    {
                        osszesCimlet.Add(címletPar.Key, címletPar.Value);
                    }
                }
            }
            List<string> lista = new();

            foreach (var par in osszesCimlet.OrderByDescending(p => p.Key))
            {
                lista.Add($"{par.Value} db {par.Key} Ft-os");
            }
            return lista;
        }
        private string MonogramKeszito(string nev)
        {
            string[] nevek = nev.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (nevek.Length >= 2)
            {
                char vBetu = nevek[0][0]; 
                char kBetu = nevek[nevek.Length - 1][0]; 
                return $"{vBetu} {kBetu}".ToUpper(); 
            }
            else if (nevek.Length == 1)
            {
                return $"{nevek[0][0]}".ToUpper();
            }
            return "??"; 
        }
        public void HatodikFeladat(string kimenetiFajl)
        {
            var fizetesek = KerekitettFizetesek();
            var rendezettFizetesek = fizetesek.OrderBy(p => p.Key);

            var sorok = new List<string>();

            foreach (var par in rendezettFizetesek)
            {
                string monogram = MonogramKeszito(par.Key);
                string sor = $"{monogram};{par.Value}";
                sorok.Add(sor);
            }
            File.WriteAllLines(kimenetiFajl, sorok);
        }
    }
}
