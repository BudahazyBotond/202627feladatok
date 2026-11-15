using Lovaglas_lib;
Datastore datas = new(["kepzes", "oktato", "orarend", "szint"]);
Console.WriteLine($"5. feladat: {datas.Legalabb45p()} lovaglás tartott legalább 45 percig.");
Console.Write("6. feladat: Az oktató neve: ");
string? oktatoNev = Console.ReadLine()!;
Console.WriteLine(datas.AdatokNevbol(oktatoNev));
