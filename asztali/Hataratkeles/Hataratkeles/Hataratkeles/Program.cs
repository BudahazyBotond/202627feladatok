using Hataratkeles_lib;
Hataratkelok lista = new Hataratkelok(File.ReadAllLines("hataratkelok.csv"));
Console.WriteLine($"1. feladat: \nA fájl adatainak száma: {lista.Db()}");
Console.WriteLine("");
Console.WriteLine($"2. faladat: \nA vasúti átkelőők száma: {lista.VasutAtkelo()}");
Console.WriteLine("");

Console.WriteLine($"3. feladat:");
foreach (Hataratkelo item in lista.MegyeiAtkelo())
{
    Console.WriteLine($"{item.TelepulesNev} - {item.SzomszedTelepules}: {item.AtkeloTipus}");
}
Console.WriteLine("");

Console.WriteLine($"4. feladat: \nAz Ausztriába vezető városi határátkelőhelyek száma: {lista.Ausztriaba()}");
Console.WriteLine("");
Console.WriteLine($"5. feladat: \nÁbécérendben az első olyan település, amelyikből határátkelő vezet Ausztriába: {lista.AbcAusztria().TelepulesNev}");
Console.WriteLine("");
Console.WriteLine($"6. feladat: \nMagyarországgal szomszédos országok: {string.Join(", ",lista.Orszagok())}");
Console.WriteLine("");
Console.WriteLine($"7. feladat: \nKözúti és vasúti határátkelővel is rendelkező városok: {string.Join(", ",lista.AbcDuplaAtkelo())}");
Console.WriteLine("");
Console.WriteLine($"8. feladat:");
foreach (var item in lista.OrszagAtkelok())
{
    Console.WriteLine($"{item.Key}: {item.Value} határátkelő");
}
Console.WriteLine("");
Console.WriteLine($"9. feladat: \nVas:");
foreach (var item in lista.LegtobbAtkelo("Vas"))
{
    Console.WriteLine($"{item.TelepulesNev} - {item.SzomszedTelepules} ({item.Orszag}) - {item.AtkeloTipus}");
}
Console.WriteLine("\nZala:");
foreach (var item in lista.LegtobbAtkelo("Zala"))
{
    Console.WriteLine($"{item.TelepulesNev} - {item.SzomszedTelepules} ({item.Orszag}) - {item.AtkeloTipus}");
}