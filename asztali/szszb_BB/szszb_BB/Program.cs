using szszb_lib;
Telepulesek lista = new Telepulesek("szszb.csv");
Console.WriteLine($"3. feladat: Települések száma {lista.Darab()} db");
Console.WriteLine($"4. feladat: Települések átlagos mérete: {lista.AtlagSzatmar()} ha");
Console.WriteLine($"5. feladat: Térségek: {string.Join(", ", lista.Tersegek())}");
Console.Write($"6. feladat: Kérem a térség nevét: ");
string tersegKeres = Console.ReadLine()!;
if (lista.KeresLegnagyobb(tersegKeres) == null)
{
    Console.WriteLine("\tA megadott térség nem létezik");
}
else
{
    Console.WriteLine($"\tA legnagyobb népsűrűségű település adatai a térségben:\n {lista.ToString(lista.KeresLegnagyobb(tersegKeres))}");
}
Console.WriteLine($"7. feladat: Település rangonként a települések száma:");
foreach(var group in lista.RangszerintiVarosok())
{
    Console.WriteLine($"{group.Key}: {group.Count()}");
}
Console.WriteLine("$8. feladat: Település rangonként a települések száma:");
foreach (var group in lista.RangszerintiVarosok())
{
    Console.WriteLine($"{group.Key}: {Math.Round(group.Sum(x=>x.lakossag)/1000.0,1)} ezer fő");
}