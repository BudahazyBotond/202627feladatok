using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamonkeres_lib
{
    public class Diak
    {
        public int MennyitKeszult { get; init; }
        public bool SokatTanul { get; init; }
        public int ID { get; init; }
        readonly List<Szamonkeres> szamonkeresek = new List<Szamonkeres>();
        readonly List<int> jegyek = new List<int>();
        public List<Szamonkeres> Szamonkeresek => szamonkeresek;
        public Diak(int mennyitKeszult, bool sokatTanul, int id)
        {
            this.MennyitKeszult = mennyitKeszult;
            this.SokatTanul = sokatTanul;
            this.ID = id;
        }
        public int Jegyszerzes(Szamonkeres szamonkeres)
        {
            int pontszam = -1;
            if (Random.Shared.Next(1, 101) > 2)
            {
                if (SokatTanul)
                {
                    pontszam = (int)(Math.Floor(((double)Random.Shared.Next(12, 21)) * MennyitKeszult / 100 * szamonkeres.Pontszam));
                }
                else
                {
                    pontszam = (int)(Math.Floor(((double)Random.Shared.Next(0, 18)) * MennyitKeszult / 100 * szamonkeres.Pontszam));
                }
            }
            szamonkeresek.Add(szamonkeres);
            jegyek.Add(szamonkeres.Jegy(pontszam));
            return pontszam;
        }
        public Szamonkeres this[int index]
        {
            get
            {
                if (index < 0 || index >= szamonkeresek.Count())
                {
                    throw new IndexOutOfRangeException($"Érvénytelen index: {index}");
                }
                return szamonkeresek[index];
            }
        }
        public override string ToString()
        {
            List<string> szovegek = new List<string>();
            for (int i = 0; i < szamonkeresek.Count(); i++)
            {
                if (szamonkeresek[i] is Beadando)
                {
                    szovegek.Add($"{jegyek[i]} ({100}%)");
                }
                else if (szamonkeresek[i] is Dolgozat)
                {
                    szovegek.Add($"{jegyek[i]} ({((Dolgozat)szamonkeresek[i]).Szazalek}%)");
                }
            }
            string elsoSor = $"Diák sorszáma: {ID}\n" + $"Jegyek: ";
            return elsoSor + string.Join(", ", szovegek);
        }
        public bool MindenMegfelelt()
        {
            return jegyek.All(x => x >= 2);
        }
    }
}
