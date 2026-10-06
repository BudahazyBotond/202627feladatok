using Halmazok_lib;
using System.Text.Json;
Menu();
List<Szemely> SzemelyekBeolvasas(string fileName)
{
    List<Szemely> szemelyek = new List<Szemely>();
    string[] sorok = File.ReadAllLines(fileName);
    foreach (var sor in sorok)
    {
        var mezok = sor.Split(';');
        if (mezok[2] == "D")
        {
            szemelyek.Add(new Diak(mezok[0], mezok[1], mezok[3]));
        }
        else if (mezok[2] == "T")
        {
            szemelyek.Add(new Tanar(mezok[0], mezok[1], mezok[3]));
        }
    }
    return szemelyek;
}
void Menu()
{
    Console.WriteLine("1. Lottó");
    Console.WriteLine("2. Kérdőív");
    Console.WriteLine("3. Kilépés");
    Console.Write("Válassz egy lehetőséget (1-3): ");
    string valasztas = Console.ReadLine()!;
    switch(valasztas)
    {
        case "1":
        {
            LottoMain();
            break;
        }
        case "2":
        {
            KerdovMain();
            break;
        }
        case "3":
        {
            Console.WriteLine("Kilépés...");
            return;
        }
        default:
        {
            Console.WriteLine("Érvénytelen választás, próbáld újra.");
            Menu();
            break;
        }
    }
}

void LottoMain()
{
    Lotto lotto = new Lotto();
    Console.WriteLine("A sorsolt számok növekvő sorrendben: "+lotto.Jatek().ToString());
}
void KerdovMain()
{
    Sorsolo<Szemely> sorsolo = new Sorsolo<Szemely>(SzemelyekBeolvasas("adatok.txt"));
    Console.Write("Mit szeretnél csinálni? (sorsolni/betölteni) ");
    string valasz = Console.ReadLine()!.ToLower();
    switch (valasz)
    {
        case "1":
            {
                Console.WriteLine("Mennyi diákot szeretnél sorsolni? ");
                int diakDb = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Mennyi tanárt szeretnél sorsolni? ");
                int tanarDb = int.Parse(Console.ReadLine()!);
                var sorsoltak = sorsolo.Sorsol(diakDb, tanarDb);
                Console.WriteLine("Sorsolt személyek:");
                foreach (var szemely in sorsoltak.Elemek)
                {
                    Console.WriteLine($"{szemely.Nev} ({(szemely.Tipus == 'D' ? "Diák" : "Tanár")})");
                }
                sorsolo.Mentes(sorsoltak, "sorsoltak");
                break;
            }
        case "2":
            {
                try 
                { 
                    var betoltottSzemelyek = sorsolo.Betolt("sorsoltak.json");
                    Console.WriteLine("Betöltött személyek:");
                    Console.WriteLine(betoltottSzemelyek.ToString());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba a fájl betöltésekor. {ex.Message}");
                    KerdovMain();
                    break;
                }
            }
        default:
            {
                Console.WriteLine("Érvénytelen választás, visszatérés a menübe.");
                Menu();
                break;
            }
    }
    }