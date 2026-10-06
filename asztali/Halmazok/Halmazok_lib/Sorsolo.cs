using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Halmazok_lib
{
    public class Sorsolo<T> where T : Szemely
    {
        private List<T> Jeloltek = new List<T>();
        private Random r = new Random();
        public Sorsolo(List<T> jeloltek)
        {
            Jeloltek = jeloltek;
        }
        public Halmaz<T> Sorsol(int db)
        {
            var sorsoltak = new Halmaz<T>();
            if (db > Jeloltek.Count)
            {
                throw new ArgumentException($"Nincs elég jelölt a sorsoláshoz, csak {Jeloltek.Count} van.");
            }
            while (sorsoltak.ElemMennyiseg < db)
            {
                var index = r.Next(0, Jeloltek.Count);
                sorsoltak.Hozzaad(Jeloltek[index]);
                Jeloltek.RemoveAt(index);
            }
            return sorsoltak;
        }

        public Halmaz<T> Sorsol(int diakDb, int tanarDb)
        {
            var sorsoltak = new Halmaz<T>();
            var diakok = Jeloltek.Where(j => j.Tipus == 'D').ToList();
            var tanarok = Jeloltek.Where(j => j.Tipus == 'T').ToList();
            if (diakDb > diakok.Count)
            {
                throw new ArgumentException($"Nincs elég diák a sorsoláshoz, csak {diakok.Count} van.");
            }
            if (tanarDb > tanarok.Count)
            {
                throw new ArgumentException($"Nincs elég tanár a sorsoláshoz, csak {tanarok.Count} van.");
            }
            if (0 > diakDb)
            {
                throw new ArgumentException($"Nem lehet minusz db diákból sorsolni");
            }
            if (0 > tanarDb)
            {
                throw new ArgumentException($"Nem lehet minusz db tanárból sorsolni");
            }
            while (sorsoltak.ElemMennyiseg < diakDb)
            {
                var index = r.Next(0, diakok.Count);
                sorsoltak.Hozzaad(diakok[index]);
                diakok.RemoveAt(index);
            }
            while (sorsoltak.ElemMennyiseg < diakDb + tanarDb)
            {
                var index = r.Next(0, tanarok.Count);
                sorsoltak.Hozzaad(tanarok[index]);
                tanarok.RemoveAt(index);
            }
            return sorsoltak;
        }

        public void Mentes(Halmaz<T> halmaz, string fajlNev)
        {
            string json = JsonSerializer.Serialize(halmaz.Elemek);
            File.WriteAllText(fajlNev+".json", json);
        }
        public Halmaz<T> Betolt(string fajlNev)
        {
            string json = File.ReadAllText(fajlNev);
            var jeloltek = JsonSerializer.Deserialize<List<T>>(json);
            return new Halmaz<T>(jeloltek!);
        }
    }
}
