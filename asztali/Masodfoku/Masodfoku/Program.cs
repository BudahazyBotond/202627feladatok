using Masodfoku;
Console.WriteLine("Adja meg az első három eggyütthatót külön külön");
int a1 = int.Parse(Console.ReadLine()!);
int b1 = int.Parse(Console.ReadLine()!);
int c1 = int.Parse(Console.ReadLine()!);
MasodfokuKifejezes k1 = new MasodfokuKifejezes(a1, b1, c1);

Console.WriteLine("Adja meg a második három eggyütthatót külön külön");
int a2 = int.Parse(Console.ReadLine()!);
int b2 = int.Parse(Console.ReadLine()!);
int c2 = int.Parse(Console.ReadLine()!);
MasodfokuKifejezes k2 = new MasodfokuKifejezes(a2, b2, c2);

Console.WriteLine($"Az első kifejezés diszkriminánsa: {k1.Diszkriminans}");
Console.WriteLine($"A második kifejezés diszkriminánsa: {k2.Diszkriminans}");

Console.WriteLine($"A két kifejezés összege: {k1+k2}");
Console.WriteLine($"A két kifejezés különbsége: {k1-k2}");

Console.WriteLine("A két kifejezés "+ (k1==k2? "egyenlő" : "nem egyenlő"));