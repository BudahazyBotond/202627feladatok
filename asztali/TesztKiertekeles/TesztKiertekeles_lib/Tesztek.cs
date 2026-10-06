using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztKiertekeles_lib
{
    public class Tesztek
    {
        public List<Teszt> tesztek = new List<Teszt>();
        public Tesztek(string[] fajl)
        {
            foreach (var sor in fajl.Skip(1))
            {
                tesztek.Add(new Teszt(sor));
            }
        }
        public bool MegirtakE() => tesztek.Count==0 ? false : true;
        public int IrokSzama(string? keres) => string.IsNullOrEmpty(keres) ? tesztek.Count(x => x.Nev == null) : tesztek.Count(x => x.Nev != null);
        public List<string?> NevKeres(string nev)
        {
            var t = tesztek.Where(x => x.Nev == nev).FirstOrDefault();
            if (t == null)
                return new List<string?> {"nincs ilyen tanuló"};
            return new List<string?> {
                t.Feladat1.HasValue ? t.Feladat1.Value.ToString() : "-",
                t.Feladat2.HasValue ? t.Feladat2.Value.ToString() : "-",
                t.Feladat3.HasValue ? t.Feladat3.Value.ToString() : "-",
                t.Feladat4.HasValue ? t.Feladat4.Value.ToString() : "-",
                t.Feladat5.HasValue ? t.Feladat5.Value.ToString() : "-",
                ((t.Feladat1.HasValue ? t.Feladat1 : 0) +
                (t.Feladat2.HasValue ? t.Feladat2 : 0) +
                (t.Feladat3.HasValue ? t.Feladat3 : 0) +
                (t.Feladat4.HasValue ? t.Feladat4 : 0) +
                (t.Feladat5.HasValue ? t.Feladat5 : 0)).ToString()
            };
        }
        public (int megoldok, double atlag, int kihagyok) FeladatStatisztika(int FeladatSzam)
        {
            var megoldok = tesztek.Where(x => x.Nev != null && x.FeladatPontszam(FeladatSzam) != null).ToList();
            int kihagyok = tesztek.Count(x => x.Nev != null && x.FeladatPontszam(FeladatSzam) == null);
            double atlag = megoldok.Any() ? megoldok.Average(x => x.FeladatPontszam(FeladatSzam).Value) : 0;
            return (megoldok.Count(), Math.Round(atlag, 2), kihagyok);
        }
        public void FajlBeiras(int csoportSzam)
        {
            StreamWriter fajl = new StreamWriter($"szazalekcsoport{ csoportSzam }.csv", false, Encoding.UTF8);
            fajl.WriteLine("sorszám;név;százalék;eredmény");

            for (int i = 0; i < tesztek.Count(); i++)
            {
                var tanulo = tesztek[i];

                if (tanulo.Nev == null) fajl.WriteLine($"{i+1}");
                else fajl.WriteLine($"{i+1};{tanulo.Nev};{Math.Round(tanulo.szazalek)}%;{tanulo.eredmeny}");
            }
            fajl.Close();
        }
        public List<string?> this[string nev]
        {
            get
            {
                var t = tesztek.Where(x => x.Nev == nev).FirstOrDefault();
                if (t == null)
                    return new List<string?> { "nincs ilyen tanuló" };
                return new List<string?> {
                    t.Feladat1.HasValue ? t.Feladat1.Value.ToString() : "-",
                    t.Feladat2.HasValue ? t.Feladat2.Value.ToString() : "-",
                    t.Feladat3.HasValue ? t.Feladat3.Value.ToString() : "-",
                    t.Feladat4.HasValue ? t.Feladat4.Value.ToString() : "-",
                    t.Feladat5.HasValue ? t.Feladat5.Value.ToString() : "-",
                    ((t.Feladat1.HasValue ? t.Feladat1 : 0) +
                    (t.Feladat2.HasValue ? t.Feladat2 : 0) +
                    (t.Feladat3.HasValue ? t.Feladat3 : 0) +
                    (t.Feladat4.HasValue ? t.Feladat4 : 0) +
                    (t.Feladat5.HasValue ? t.Feladat5 : 0)).ToString()
                };
            }
        }
    }

}
