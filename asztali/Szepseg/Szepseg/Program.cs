using Szepseg_lib;
Datastore datas = new(["alkalmazottak", "kezelesek", "szakmak", "vendegek"]);

Console.WriteLine($"5. feladat: {datas.KezelesekList.DelelottiKezelesek()} kezelés esett délelőttre");
Console.Write($"6. feladat: A vendég neve: ");
string vendegNeve = Console.ReadLine()!;
if (datas.VendegekList[vendegNeve] != null)
{
    Console.WriteLine($"\tCím: {datas.VendegekList[vendegNeve]!.Cim}\n\tTelefon: {datas.VendegekList[vendegNeve]!.Telefon}");
}
else Console.WriteLine("\tIlyen néven nem található vendég");
Console.WriteLine($"7. A 3 legmagasabb bevételű alkalmazott: \n{datas.Top3()}");