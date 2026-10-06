namespace Labirintus_lib
{
    public class LabSim
    {
        private List<string> Adatsorok;
        private char[,] Lab;
        private int SorokSzama;
        private int OszlopokSzama;
        private int KijaratSorIndex;
        private int KijaratOszlopIndex;

        public LabSim(string forrasAllomany)
        {
            Adatsorok = new List<string>();
            BeolvasAdatsorok(forrasAllomany);
            MeretMeghatarozas();
            Lab = new char[SorokSzama, OszlopokSzama];
            FeltoltLab();
            KijaratIndexekMeghatarozasa();
        }

        private void BeolvasAdatsorok(string forrasAllomany)
        {
            using (StreamReader sr = new StreamReader(forrasAllomany))
            {
                string sor;
                while ((sor = sr.ReadLine()) != null)
                {
                    Adatsorok.Add(sor);
                }
            }
        }

        private void MeretMeghatarozas()
        {
            SorokSzama = Adatsorok.Count;
            OszlopokSzama = 0;
            foreach (string sor in Adatsorok)
            {
                if (sor.Length > OszlopokSzama)
                    OszlopokSzama = sor.Length;
            }
        }

        private void FeltoltLab()
        {
            for (int i = 0; i < SorokSzama; i++)
            {
                string sor = Adatsorok[i];
                for (int j = 0; j < OszlopokSzama; j++)
                {
                    if (j < sor.Length)
                        Lab[i, j] = sor[j];
                    else
                        Lab[i, j] = ' ';
                }
            }
        }

        private void KijaratIndexekMeghatarozasa()
        {
            KijaratSorIndex = SorokSzama - 2;
            KijaratOszlopIndex = OszlopokSzama - 1;
        }

        public void KiirLab()
        {
            for (int i = 0; i < SorokSzama; i++)
            {
                for (int j = 0; j < OszlopokSzama; j++)
                {
                    Console.Write(Lab[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Utkereses(bool szimulacio = false)
        {
            bool KeresesKesz = false;
            bool NincsMegoldas = false;
            int r = 1;
            int c = 0;

            while (!KeresesKesz && !NincsMegoldas)
            {
                if (Lab[r, c] != '0')
                    Lab[r, c] = '0';

                if (c + 1 < OszlopokSzama && Lab[r, c + 1] == ' ')
                {
                    c++;
                }
                else if (r + 1 < SorokSzama && Lab[r + 1, c] == ' ')
                {
                    r++;
                }
                else
                {
                    Lab[r, c] = '-';
                    if (c - 1 >= 0 && Lab[r, c - 1] == '0')
                    {
                        c--;
                    }
                    else if (r - 1 >= 0 && Lab[r - 1, c] == '0')
                    {
                        r--;
                    }
                }

                KeresesKesz = (r == KijaratSorIndex && c == KijaratOszlopIndex);
                if (KeresesKesz)
                    Lab[r, c] = '0';

                NincsMegoldas = (r == 1 && c == 0 && Lab[r, c] == '-');

                if (szimulacio)
                {
                    Console.Clear();
                    Console.WriteLine("8. feladat - Szimuláció");
                    KiirLab();
                    Thread.Sleep(300);
                }
            }
        }

        public int GetSorokSzama() => SorokSzama;
        public int GetOszlopokSzama() => OszlopokSzama;
        public int GetKijaratSorIndex() => KijaratSorIndex;
        public int GetKijaratOszlopIndex() => KijaratOszlopIndex;
    }
}