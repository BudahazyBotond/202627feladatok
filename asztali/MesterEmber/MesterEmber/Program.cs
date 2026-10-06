using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MesterEmberApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<MesterEmberLib.MesterEmber> mesterek = new List<MesterEmberLib.MesterEmber>();

                // 7a. Beolvasás fájlból
                Console.WriteLine("Mesterek betöltése...");
                string[] sorok = File.ReadAllLines("input.txt", Encoding.UTF8);

                foreach (string sor in sorok)
                {
                    try
                    {
                        var mester = MesterEmberLib.MesterFactory.Factory(sor);
                        mesterek.Add(mester);
                        Console.WriteLine($"Hozzáadva: {mester.Nev}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba a sor feldolgozásakor: {sor}");
                        Console.WriteLine($"Hibaüzenet: {ex.Message}");
                    }
                }

                // 7b. Megrendelések szimulálása
                Console.WriteLine("\nMegrendelések feldolgozása...");
                Random rnd = new Random();
                StringBuilder eredmeny = new StringBuilder();

                foreach (var mester in mesterek)
                {
                    eredmeny.AppendLine($"=== Mester: {mester.Nev} ===");

                    int megrendelesekSzama = mester is MesterEmberLib.Burkolo ? 25 : 10;
                    int sikeres = 0;
                    int sikertelen = 0;

                    for (int i = 1; i <= megrendelesekSzama; i++)
                    {
                        int nap = rnd.Next(1, 32); // 1-31

                        try
                        {
                            bool siker = mester.MunkatVallal(nap);

                            if (siker)
                            {
                                eredmeny.AppendLine($"{i}. megrendelés: nap {nap} - SIKERES");
                                sikeres++;
                            }
                            else
                            {
                                eredmeny.AppendLine($"{i}. megrendelés: nap {nap} - SIKERTELEN (a mester foglalt vagy a vízvezetékszerelőnek nincs 3 szabad napja)");
                                sikertelen++;
                            }
                        }
                        catch (MesterEmberLib.TulSokFoglaltsagException ex)
                        {
                            eredmeny.AppendLine($"{i}. megrendelés: nap {nap} - SIKERTELEN (túl sok foglaltság: {ex.Message})");
                            sikertelen++;
                        }
                        catch (Exception ex)
                        {
                            eredmeny.AppendLine($"{i}. megrendelés: nap {nap} - HIBA: {ex.Message}");
                            sikertelen++;
                        }
                    }

                    eredmeny.AppendLine($"Összesítés: {sikeres} sikeres, {sikertelen} sikertelen");
                    eredmeny.AppendLine($"Szabad napok száma: {mester.SzabadnapokSzama}");
                    eredmeny.AppendLine();
                }

                // Eredmények mentése
                File.WriteAllText("megrendelcsek.txt", eredmeny.ToString(), Encoding.UTF8);
                Console.WriteLine($"Eredmények mentve: megrendelcsek.txt");

                // 7c. További információk kiírása
                Console.WriteLine("\nStatisztika:");
                Console.WriteLine($"Összes mester: {mesterek.Count}");

                int burkolok = 0;
                int szerelok = 0;
                foreach (var mester in mesterek)
                {
                    if (mester is MesterEmberLib.Burkolo) burkolok++;
                    if (mester is MesterEmberLib.VizvezetekSzerelo) szerelok++;
                }

                Console.WriteLine($"Burkolók: {burkolok}");
                Console.WriteLine($"Vízvezetékszerelők: {szerelok}");

                // Mesterek listájának kiírása
                Console.WriteLine("\nMesterek részletes információk:");
                foreach (var mester in mesterek)
                {
                    Console.WriteLine(mester);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Hiba: Az input.txt fájl nem található!");
                // Példa tartalom létrehozása, ha nem létezik a fájl
                CreateSampleInputFile();
                Console.WriteLine("Minta input.txt fájl létrehozva. Futtasd újra a programot!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Váratlan hiba: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }

            Console.WriteLine("\nNyomj egy billentyűt a kilépéshez...");
            Console.ReadKey();
        }

        static void CreateSampleInputFile()
        {
            string[] mintaAdatok = {
                "b;Kovács János;25000;külső",
                "b;Nagy Péter;22000;belső",
                "v;Szabó István;5",
                "v;Tóth Gábor;8",
                "b;Horváth Éva;28000;külső",
                "v;Kiss Miklós;3"
            };

            File.WriteAllLines("input.txt", mintaAdatok, Encoding.UTF8);
        }
    }
}