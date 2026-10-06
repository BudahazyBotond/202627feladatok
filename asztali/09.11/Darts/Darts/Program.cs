using Darts_lib;
Dobasok lista = new(File.ReadAllLines("dobasok.txt"));
Console.WriteLine($"2. feladat \nKörök száma: {lista.Korok()}");
Console.WriteLine($"3. feladat \n3. dobásra Bullseye: {lista.HarmadikBulls()}");
Console.Write("Adja meg a szektor értékét! Szektor= ");
string szektor = Console.ReadLine()!;
Console.WriteLine($"Az 1. játékos a(z) {szektor} szektoros dobásainak száma: {lista.Szektor(szektor)[0]} \nA 2. játékos a(z) {szektor} szektoros dobásainak száma: {lista.Szektor(szektor)[1]}");
Console.WriteLine($"5. feladat \nAz 1. játékos {lista.MaxPont()[0]} db 180-ast dobott. \nA 2. játékos {lista.MaxPont()[1]} db 180-ast dobott.");