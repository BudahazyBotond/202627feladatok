using Szamonkeres_lib;

List<Szamonkeres> szamonkeresek = FajlBeolvasas("input.txt");
List<Diak> diakok = new List<Diak>();
Random r = new Random();
for (int i = 1; i <= 10; i++)
{
    diakok.Add(new Diak(r.Next(0, 6), r.Next(0, 2) == 0, i));
}
foreach (Diak diak in diakok)
{
    foreach (Szamonkeres szamonkeres in szamonkeresek)
    {
        try
        {
            diak.Jegyszerzes(szamonkeres);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}
foreach (Diak diak in diakok)
{
    try
    {
        Console.WriteLine(diak.ToString());
    }
    catch (Exception exc)
    {
        Console.WriteLine(exc.Message);
    }
}
int elegsegesekSzama = 0;
foreach (Diak diak in diakok)
{
    if (diak.MindenMegfelelt())
    {
        elegsegesekSzama++;
    }
}
Console.WriteLine($"Megfelelt diákok: {elegsegesekSzama} fő");
List<Szamonkeres> FajlBeolvasas(string fajlNev)
{
    string[] fajlSorok = File.ReadAllLines(fajlNev);
    List<Szamonkeres> szamonkeresek = new List<Szamonkeres>();
    SzamonkeresFactory factory = new SzamonkeresFactory();

    foreach (var fajlSor in fajlSorok)
    {
        szamonkeresek.Add(factory.Factory(fajlSor));
    }
    return szamonkeresek;
}