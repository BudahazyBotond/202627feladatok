using Konyvtar_lib;
Konyvek lista = new(File.ReadAllLines("konyvek.txt"));
Console.WriteLine($"3. feladat: A könyvek száma: {lista.KonyvAdatai()} db");
Console.WriteLine($"4. feladat: A kölcsönözhető könyvek száma: {lista.KolcsonozhetoKonyvek()} db");
Console.WriteLine($"5. feladat: Harry Potter könyvek száma {lista.HarryPotterKonyvek()} db");
foreach (var item in lista.Legtobbkonyv())
{
    Console.WriteLine($"6. feladat: A legtöbb könyvet {item.Key} évben adták ki {item.Count()} db");
}
Console.WriteLine($"7. feladat: Könyvek évenkénti darabszáma:");
foreach (var item in lista.EvesKonyvek())
{
    Console.WriteLine($"\t{item.Key}: {item.Count()} db");
}
Console.WriteLine("8. feladat: Szerzők és könyveinek száma: ");
foreach (var item in lista.SzerzoKonyvek())
{
    Console.WriteLine($"\t{item.Key}: {item.Count()} db");
}
Console.Write("9. feladat: Adjon meg egy könyvcímet: ");
string bekertcim = Console.ReadLine()!;
Console.WriteLine(lista.KonyvCim(bekertcim));
Console.WriteLine($"10. feladat: Kölcsönözhető könyvek listája: {string.Join(",",lista.Kolcsonozheto())}");