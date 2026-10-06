using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Autoverseny_lib.KategoriakEnum;

namespace Autoverseny_lib
{
    public class Verseny
    {
        private List<Versenyzo> versenyzok;
        private int korokSzama;
        private Random random;

        public Verseny(string fajlNev)
        {
            versenyzok = new List<Versenyzo>();
            random = new Random();
            Beolvas(fajlNev);
        }

        private void Beolvas(string fajlNev)
        {
            try
            {
                string[] sorok = File.ReadAllLines(fajlNev);
                string[] elsoSor = sorok[0].Split(' ');
                korokSzama = int.Parse(elsoSor[0]);
                int versenyzoSzam = int.Parse(elsoSor[1]);

                for (int i = 1; i <= versenyzoSzam; i++)
                {
                    string[] adatok = sorok[i].Split(' ');
                    string nev = adatok[0];
                    Kategoria kategoria = (Kategoria)int.Parse(adatok[1]);
                    versenyzok.Add(new Versenyzo(nev, kategoria, i - 1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a fájl beolvasásakor: {ex.Message}");
                throw;
            }
        }

        public void Szimulacio()
        {
            Console.WriteLine($"Verseny kezdődik! {korokSzama} kör, {versenyzok.Count} versenyző\n");

            for (int kor = 1; kor <= korokSzama; kor++)
            {
                Console.WriteLine($"=== {kor}. kör ===");

                // Kör kezdete - benzin fogyasztás
                foreach (var versenyzo in versenyzok.Where(v => !v.Kiesett))
                {
                    versenyzo.Benzin -= 5;
                    versenyzo.Korok++;

                    EllenorizTankolast(versenyzo);
                }

                // Előzési próbálkozások
                foreach (var versenyzo in versenyzok.Where(v => !v.Kiesett).OrderBy(v => v.Helyezes))
                {
                    // Ha tankolt most, ne próbálkozzon előzni
                    if (versenyzo.Benzin == 100) continue;

                    bool probalElozni = false;

                    // Kategória specifikus előzési logika
                    switch (versenyzo.Kategoria)
                    {
                        case Kategoria.Agressziv:
                            if (kor % 2 == 0)
                            {
                                probalElozni = true;
                            }
                            break;
                        case Kategoria.Lenduletes:
                            if (kor % 5 == 0)
                            {
                                probalElozni = true;
                            }
                            break;
                        case Kategoria.Veszelyes:
                            if (kor % 4 == 0)
                            {
                                probalElozni = true;
                            }
                            break;
                        case Kategoria.Ovatos:
                            // Óvatos soha nem próbálkozik előzni
                            break;
                    }

                    if (probalElozni)
                    {
                        Elozes(versenyzo, kor);
                    }
                }

                // Kiesett versenyzők eltávolítása a sorrendből
                var kiesettek = versenyzok.Where(v => v.Kiesett && v.Korok == kor).ToList();
                if (kiesettek.Any())
                {
                    Console.WriteLine("Kiesett(ek): " + string.Join(", ", kiesettek.Select(v => v.Nev)));
                }

                // Aktuális sorrend kiírása
                var aktivVersenyzok = versenyzok
                    .Where(v => !v.Kiesett)
                    .OrderBy(v => v.Helyezes)
                    .ToList();

                Console.WriteLine("Sorrend:");
                for (int i = 0; i < aktivVersenyzok.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {aktivVersenyzok[i]}");
                }
                Console.WriteLine();

                // Ha csak egy versenyző marad, vége a versenynek
                if (versenyzok.Where(v => !v.Kiesett).Count() == 1)
                {
                    Console.WriteLine($"Csak egy versenyző maradt: {aktivVersenyzok[0].Nev} nyert!");
                    break;
                }

                // Ha mindenki kiesett, vége a versenynek
                if (versenyzok.All(v => v.Kiesett))
                {
                    Console.WriteLine("Minden versenyző kiesett!");
                    break;
                }
                Console.WriteLine("Nyomjon egy gombot a továbblépéshez!");
                Console.ReadKey();
                Console.Clear();


            }

            EredmenyekKiirasa();
        }

        private void EllenorizTankolast(Versenyzo versenyzo)
        {
            bool tankolniKell = false;

            switch (versenyzo.Kategoria)
            {
                case Kategoria.Agressziv:
                    tankolniKell = versenyzo.Benzin < 10;
                    break;
                case Kategoria.Lenduletes:
                    tankolniKell = versenyzo.Benzin < 20;
                    break;
                case Kategoria.Veszelyes:
                    tankolniKell = versenyzo.Benzin < 5;
                    break;
                case Kategoria.Ovatos:
                    tankolniKell = versenyzo.Benzin < 20;
                    break;
            }

            if (tankolniKell)
            {
                Console.WriteLine($"{versenyzo.Nev} kiállt tankolni!");
                versenyzo.Benzin = 100;

                // 5 hellyel hátrébb kerül
                int ujHelyezes = Math.Min(versenyzok.Count(), versenyzo.Helyezes + 5);
                var aktivVersenyzok = versenyzok.Where(v => !v.Kiesett).ToList();
                if (ujHelyezes >= aktivVersenyzok.Count)
                {
                    ujHelyezes = aktivVersenyzok.Count - 1;
                }
                versenyzo.Helyezes = ujHelyezes;

                // Átrendezzük a többi versenyzőt
                foreach (var v in versenyzok.Where(v => !v.Kiesett && v.Helyezes >= ujHelyezes && v != versenyzo))
                {
                    v.Helyezes--;
                }
            }
        }

        private void Elozes(Versenyzo tamado, int kor)
        {
            // Előzés benzin költsége
            tamado.Benzin -= 4;

            // Előzés sikerességének ellenőrzése
            bool sikeres = false;
            switch (tamado.Kategoria)
            {
                case Kategoria.Agressziv:
                    // Minden harmadik előzése sikeres
                    sikeres = (1 / 3) > random.NextDouble();
                    break;
                case Kategoria.Lenduletes:
                    // Minden második sikeres
                    sikeres = 0.5 > random.NextDouble();
                    break;
                case Kategoria.Veszelyes:
                    // Minden negyedik sikeres
                    sikeres = 0.25 > random.NextDouble();
                    break;
            }

            if (sikeres)
            {
                // Megkeressük az előzendő versenyzőt (az előtte lévőt)
                var celpont = versenyzok
                    .Where(v => !v.Kiesett && v.Helyezes == tamado.Helyezes - 1)
                    .FirstOrDefault();

                if (celpont != null)
                {
                    // Baleset ellenőrzése
                    if (!Baleset(tamado, celpont))
                    {
                        // Sikeres előzés
                        tamado.Helyezes--;
                        celpont.Helyezes++;
                        Console.WriteLine($"{tamado.Nev} sikeresen előzte meg {celpont.Nev}-t!");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{tamado.Nev} próbált előzni, de nem sikerült.");
            }
        }

        private bool Baleset(Versenyzo tamado, Versenyzo celpont)
        {
            // Baleset esélyei
            double tamadoKiesesEsely = 0.04;
            double mindkettenKiesnekEsely = 0.04;
            double tomegkarambolEsely = 0.02;

            // Veszélyes versenyzők esetén duplázódnak az esélyek
            if (tamado.Kategoria == Kategoria.Veszelyes)
            {
                tamadoKiesesEsely *= 2;
                mindkettenKiesnekEsely *= 2;
                tomegkarambolEsely *= 2;
            }

            double veletlen = random.NextDouble();
            double osszEsely = tamadoKiesesEsely + mindkettenKiesnekEsely + tomegkarambolEsely;

            if (veletlen < tamadoKiesesEsely)
            {
                // Csak a támadó kiesik
                Console.WriteLine($"BALESET! {tamado.Nev} kiesett az előzés közben!");
                tamado.Kiesett = true;
                return true;
            }
            else if (veletlen < tamadoKiesesEsely + mindkettenKiesnekEsely)
            {
                // Mindketten kiesnek
                Console.WriteLine($"BALESET! {tamado.Nev} és {celpont.Nev} mindketten kiestek!");
                tamado.Kiesett = true;
                celpont.Kiesett = true;
                return true;
            }
            else if (veletlen < osszEsely)
            {
                // Tömegkarambol - 4 versenyző esik ki
                Console.WriteLine($"NAGY BALESET! Tömegkarambol!");

                var aktivVersenyzok = versenyzok
                    .Where(v => !v.Kiesett)
                    .OrderBy(v => v.Helyezes)
                    .ToList();

                int tamadoIndex = aktivVersenyzok.IndexOf(tamado);
                int celpontIndex = aktivVersenyzok.IndexOf(celpont);

                // Előtte és mögötte lévők keresése
                int[] kiesokIndexe = new int[]
                {
                    Math.Max(0, tamadoIndex - 1),
                    tamadoIndex,
                    celpontIndex,
                    Math.Min(aktivVersenyzok.Count - 1, tamadoIndex + 2)
                };

                foreach (var index in kiesokIndexe.Distinct())
                {
                    if (index < aktivVersenyzok.Count)
                    {
                        aktivVersenyzok[index].Kiesett = true;
                        Console.WriteLine($"  {aktivVersenyzok[index].Nev} kiesett!");
                    }
                }
                return true;
            }

            return false;
        }

        private void EredmenyekKiirasa()
        {
            Console.WriteLine("\n=== VERSENY VÉGE ===");
            Console.WriteLine("Végeredmény:");

            var vegsoSorrend = versenyzok
                .Where(v => !v.Kiesett)
                .OrderBy(v => v.Helyezes)
                .ToList();

            if (vegsoSorrend.Count == 0)
            {
                Console.WriteLine("Nincs befutó!");
                return;
            }

            for (int i = 0; i < Math.Min(3, vegsoSorrend.Count); i++)
            {
                Console.WriteLine($"{i + 1}. helyezett: {vegsoSorrend[i].Nev}");
            }

            // Kiesettek listája
            var kiesettek = versenyzok.Where(v => v.Kiesett).ToList();
            if (kiesettek.Any())
            {
                Console.WriteLine("\nKiesett versenyzők:");
                foreach (var kiesett in kiesettek)
                {
                    Console.WriteLine($"  {kiesett.Nev}");
                }
            }
        }
    }
}
