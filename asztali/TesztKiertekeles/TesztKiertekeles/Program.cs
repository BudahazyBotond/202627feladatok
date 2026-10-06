using TesztKiertekeles_lib;
Console.Write("Melyik csoport eredményét szeretnéd beolvasni? ");
string csop = Console.ReadLine()!;
Tesztek lista;
if(csop == "1")
{
    lista = new Tesztek(File.ReadAllLines("csoport1.csv"));
}
else if(csop == "2")
{
    lista = new Tesztek(File.ReadAllLines("csoport2.csv"));
}
else
{
    string[] ures = [];
    lista = new(ures);
    Console.WriteLine("Nincs ilyen csoport!");
}
if (lista.MegirtakE())
{
    
    Console.WriteLine("1. feladat:");
    Console.WriteLine($"Ennyi tanuló írta meg: {lista.IrokSzama(" ")}");
    Console.WriteLine($"Ennyi tanuló nem írta meg: {lista.IrokSzama(null)}");
    Console.WriteLine("2. feladat:");
    Console.Write("Add meg a tanuló nevét ");
    string nev = Console.ReadLine()!;
    Console.WriteLine($"{nev}: {string.Join(",",lista[nev])}");
    Console.WriteLine("3. feladat:");
    for (int i = 1; i <= 5; i++)
    {
        var (megoldok, atlag, kihagyok) = lista.FeladatStatisztika(i);
        Console.WriteLine($"{i}. feladat statisztikái:\tMegoldotta: {megoldok} tanuló\tMeogoldottak Átlaga: {atlag}\tKihagyta: {kihagyok} tanuló");
    }
    lista.FajlBeiras(int.Parse(csop));
}
