using Autoverseny_lib;

Console.WriteLine("Autóverseny szimuláció");
Console.Write("Adja meg a fájl nevét: ");
string fajlNev = Console.ReadLine()!;

try
{
    Verseny verseny = new Verseny(fajlNev);
    verseny.Szimulacio();
}
catch (Exception ex)
{
    Console.WriteLine($"Hiba történt: {ex.Message}");
}

Console.WriteLine("\nNyomjon Enter-t a kilépéshez...");
Console.ReadLine();