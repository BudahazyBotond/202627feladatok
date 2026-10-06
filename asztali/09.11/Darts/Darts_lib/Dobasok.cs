using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts_lib
{
    public class Dobasok
    {
        readonly List<Dobas> list = new();
        public Dobasok(string[] file)
        {
            foreach (var sor in file)
            {
                string[] adatok = sor.Split(';');
                list.Add(new Dobas(adatok));
            }
        }
        public int Korok() => list.Count(x=>x.Player==1);
        public int HarmadikBulls() => list.Count(x=>x.Harmadik=="D25");
        public int[] Szektor(string szektor)
        {
            int[] jatekosok = new int[2];
            foreach (var item in list)
            {
                if (item.Elso == szektor) jatekosok[item.Player - 1]++;
                if (item.Masodik == szektor) jatekosok[item.Player - 1]++;
                if (item.Harmadik == szektor) jatekosok[item.Player - 1]++;
            }
            return jatekosok;
        }
        public int[] MaxPont()
        {
            int[] jatekosok = new int[2];
            foreach (var item in list)
            {
                if (item.Elso == "T20"&& item.Masodik == "T20" && item.Harmadik == "T20") jatekosok[item.Player - 1]++;
            }
            return jatekosok;
        }

    }
}
