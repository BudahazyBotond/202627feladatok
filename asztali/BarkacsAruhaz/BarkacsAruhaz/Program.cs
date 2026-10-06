using BarkacsAruhaz_lib;
File.Delete("hibalista.txt");
string[] szerszamokFile = File.ReadAllLines("szerszamok.txt");
List<Szerszam> elerhetoSzerszamok = new();
foreach(string sor in szerszamokFile.Skip(1))
{
    string[] adatok = sor.Split(';');
    elerhetoSzerszamok.Add(new Szerszam(adatok[0], adatok[1], adatok[2], int.Parse(adatok[3])));
}
Szerszamok szerszamok = new(elerhetoSzerszamok);

Console.WriteLine($"Elérhető kéziszerszámok: \n{string.Join("\n", szerszamok.KeziSzerszamok())}");

string[] keszletekFile = File.ReadAllLines("keszletek.txt");
List<string> hibak = new();
List<SzerszamElem> szerszamElemek = new();
foreach(string sor in keszletekFile)
{
    try
    {
        szerszamElemek.Add(SzerszamFactory.Factory(sor, szerszamok));
    }
    catch(Exception e)
    {
        hibak.Add($"{e.Message} ({sor})");
    }
}
Console.WriteLine($"\nElkészített objektumok: \n{string.Join("\n", szerszamElemek)}");

Console.WriteLine($"\nHibák száma: {hibak.Count()}");

File.WriteAllLines("hibalista.txt", hibak);