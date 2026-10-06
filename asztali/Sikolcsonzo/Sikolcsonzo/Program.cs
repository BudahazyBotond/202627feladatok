using Sikolcsonzo_lib;
File.Delete("hibalista.txt");
List<Sporteszkoz> alapSporteszkozok = new();
string[] sporteszkozokFile = File.ReadAllLines("sporteszkozok.txt").ToList().Skip(1).ToArray();
foreach(string sor in sporteszkozokFile)
{
    alapSporteszkozok.Add(SporteszkozFactory.Factory(sor));
}
Kolcsonzesek kolcsonzesek = new(alapSporteszkozok);
string[] foglalasokFile = File.ReadAllLines("foglalasok.txt").ToList().Skip(1).ToArray();
IEnumerable<string> hibak =  kolcsonzesek.SporteszkozBerles(foglalasokFile.ToList());
File.WriteAllLines("hibalista.txt",hibak);

Console.WriteLine($"A kölcsönözhető sporteszközök: \n\t{string.Join("\n\t",kolcsonzesek.Leirasok)}\n");

Console.WriteLine($"A sporteszközök sikeres foglalásai:");
foreach(Sporteszkoz eszkoz in kolcsonzesek.Sportszerek)
{
    if (!eszkoz.Foglalasok.IsEmpty)
    {
        Console.WriteLine(eszkoz.ToString());
    }
}
Console.Write("\nAdd meg a kölcsönzés első napját! (pl: 2025.01.13) ");
DateOnly elsoNap = DateOnly.Parse(Console.ReadLine()!);
Console.Write("Add meg, hány napig kölcsönöznél sílécet vagy snowboardot! ");
int napok = int.Parse(Console.ReadLine()!);
Console.WriteLine("A megadott időszakban kölcsönözhető sporteszközök:");
foreach(Sporteszkoz eszkoz in kolcsonzesek.SzabadSporteszkozok(elsoNap, napok))
{
    Console.WriteLine($"\t{eszkoz.Azonosito} {eszkoz.Leiras}, {eszkoz.Meret} cm");
}
