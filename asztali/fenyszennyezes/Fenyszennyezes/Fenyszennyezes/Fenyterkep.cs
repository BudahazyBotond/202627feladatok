using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenyszennyezes
{
    public class Fenyterkep
    {
        private readonly int[,] terkep;
        public int sorDb { get; }
        public int oszlopDb { get; }

        public Fenyterkep(string fajlnev)
        {
            string[] sorok = File.ReadAllLines(fajlnev);
            string[] meretek = sorok[0].Split(' ');
            sorDb = int.Parse(meretek[0]);
            oszlopDb = int.Parse(meretek[1]);
            terkep = new int[sorDb, oszlopDb];

            for (int i = 0; i < sorDb; i++)
            {
                string[] adatok = sorok[i + 1].Split('\t');
                for (int j = 0; j < oszlopDb; j++)
                {
                    terkep[i, j] = int.Parse(adatok[j]);
                }
            }
        }

        public int Ertek(int sor, int oszlop) => terkep[sor, oszlop];
        public int this[int sor, int oszlop] => terkep[sor, oszlop];
        public double SotetSzazalek()
        {
            double sotetDb = 0;
            foreach (var ertek in terkep)
            {
                if (ertek == 0) sotetDb++;
            }
            return (sotetDb / (sorDb * oszlopDb)) * 100.0;
        }

        public (int MaxErtek, List<(int Sor, int Oszlop)> Koordinatak) Legfenyesebb()
        {
            int max = -1;
            var koords = new List<(int Sor, int Oszlop)>();

            for (int i = 0; i < sorDb; i++)
            {
                for (int j = 0; j < oszlopDb; j++)
                {
                    int ertek = terkep[i, j];
                    if (ertek > max)
                    {
                        max = ertek;
                        koords.Clear();
                        koords.Add((i + 1, j + 1));
                    }
                    else if (ertek == max)
                    {
                        koords.Add((i + 1, j + 1));
                    }
                }
            }
            return (max, koords);
        }

        public List<(int Sor, int Oszlop)> FenyesPontok()
        {
            var pontok = new List<(int Sor, int Oszlop)>();
            int[] dSor = { -1, 1, 0, 0 };
            int[] dOszlop = { 0, 0, -1, 1 };

            for (int i = 0; i < sorDb; i++)
            {
                for (int j = 0; j < oszlopDb; j++)
                {
                    int ertek = terkep[i, j];
                    bool fenyesebb = true;

                    for (int k = 0; k < 4; k++)
                    {
                        int szomszedSor = i + dSor[k];
                        int szomszedOszlop = j + dOszlop[k];

                        if (szomszedSor >= 0 && szomszedSor < sorDb &&
                            szomszedOszlop >= 0 && szomszedOszlop < oszlopDb)
                        {
                            if (ertek <= terkep[szomszedSor, szomszedOszlop])
                            {
                                fenyesebb = false;
                                break;
                            }
                        }
                    }

                    if (fenyesebb)
                    {
                        pontok.Add((i, j));
                    }
                }
            }
            return pontok;
        }

        public ((int Sor, int Oszlop) BalFelso, (int Sor, int Oszlop) JobbAlso)? Befoglalo(List<(int Sor, int Oszlop)> pontok)
        {
            if (pontok.Count == 0) return null;

            int minSor = pontok.Min(p => p.Sor);
            int maxSor = pontok.Max(p => p.Sor);
            int minOszlop = pontok.Min(p => p.Oszlop);
            int maxOszlop = pontok.Max(p => p.Oszlop);

            return ((minSor + 1, minOszlop + 1), (maxSor + 1, maxOszlop + 1));
        }

        public void Diagram(int oszlop, string fajlnev)
        {
            using StreamWriter iro = new(fajlnev);
            for (int i = 0; i < sorDb; i++)
            {
                int ertek = terkep[i, oszlop];
                int csillagDb = (int)Math.Round(ertek / 10.0);
                iro.WriteLine(new string('*', csillagDb));
            }
        }
    }
}
