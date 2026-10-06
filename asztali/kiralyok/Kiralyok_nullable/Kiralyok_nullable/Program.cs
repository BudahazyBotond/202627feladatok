using HungarianKings_LIB;
using System.Data;

Kiralyok list = new Kiralyok(File.ReadAllLines("uralkodo.csv").Skip(1));

Console.WriteLine("2.feladat: A 14. században megkoronázott uralkodók:");
foreach (var r in list.ByCrownYear(1300, 1399))
{
    Console.WriteLine($"\t{r.Name.PadRight(12)}{r.Start.ToString().PadRight(6)}{r.End}");
}

Console.WriteLine("3.feladat: Magyar királyok:");
foreach (var r in list.ByBirthDesc())
{
    Console.WriteLine($"\t{r.FullName()}     {r.Born}");
}

Console.WriteLine("4.feladat: Fiatal uralkodók:");
foreach (var r in list.YoungerThan(14))
{
    if (r.WasBaby())
        Console.WriteLine($"\t{r.Name.PadRight(12)}újszülött");
    else
        Console.WriteLine($"\t{r.Name.PadRight(12)}{r.AgeAtStart} éves");
}

Console.WriteLine("5.feladat: Hosszú uralkodás:");
foreach (var r in list.LongestRule(10))
{
    Console.WriteLine($"\t{r.FullName()}    {r.YearsRuled} év");
}

Console.WriteLine("6.feladat: Uralkodó házak:");
foreach (var h in list.HouseCounts)
{
    Console.WriteLine($"\t{h.Key}\t{h.Value} király");
}

Console.WriteLine("7.feladat: Koronázás előtt már uralkodó:");
foreach (var r in list.RuledBeforeCrown)
{
    Console.WriteLine($"\t{r.Name}");
}

list.WriteToFile("melleknev.txt", list.WithNickname);