using HanoiTorony_lib;
Console.Write("Add meg hány korongal szeretnél játszani: ");
int hanyKorong= int.Parse(Console.ReadLine()!);


Torony tornyok = new Torony(hanyKorong);
while (tornyok.GameState)
{
    Console.Clear();
    Console.WriteLine(tornyok.ToString());
    Console.Write("\n\nHonnan szeretnél mozgatni?(a, b, c) ");
    string honnan = Console.ReadLine()!;
    Console.Write("\n\nHova szeretnél mozgatni?(a, b, c) ");
    string hova = Console.ReadLine()!;
    tornyok.Mozgat(honnan, hova);
    tornyok.WinCon();
}
Console.Clear();
Console.WriteLine(tornyok.ToString());
Console.WriteLine("\nNyertél!");