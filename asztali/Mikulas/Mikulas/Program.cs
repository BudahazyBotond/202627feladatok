using Mikulas_lib;

File.Delete("hibalista.txt");
GyartasAdatok gyartasTipusok = new(GyartasTipusBeolvasas("gyartas.txt"));
Console.WriteLine($"Elérhető gyártás azonosítók: {String.Join("; ", gyartasTipusok.ElerhetoGyartasAzonositok)}");
Console.WriteLine();

Jatekok jatekTipusok = new(AjandekTipusBeolvasas("ajandekok.txt"));
Console.WriteLine($"A gyártott játékok: {String.Join(", ", jatekTipusok.JatekTipusok)}");
Console.WriteLine();

Feladatok feladatok = FeladatHozzaadas();
Console.WriteLine("Az elvégezendő feladatok:");
foreach (var feladat in feladatok.FeladatLista)
{
    Console.WriteLine($"\t{feladat}");
}
Console.WriteLine();

foreach (var item in feladatok.FeladatokOsszMennyisege())
{
    Console.WriteLine($"\t{item.Key}: {item.Value} db");
}

IEnumerable<GyartasAdat> GyartasTipusBeolvasas(string fajlnev)
{
    foreach (var sor in File.ReadLines(fajlnev).Skip(1))
    {
        yield return new GyartasAdat(sor);
    }
}

IEnumerable<Jatek> AjandekTipusBeolvasas(string fajlnev)
{
    foreach (var sor in File.ReadLines(fajlnev).Skip(1))
    {
        yield return JatekFactory.Factory(sor, gyartasTipusok);
    }
}

IEnumerable<Feladat> FeladatokBeolvasas(string fajlnev)
{
    foreach (var sor in File.ReadLines(fajlnev).Skip(1))
    {
        string[] adatsor = sor.Split(';');
        Jatek? jatek = jatekTipusok[adatsor[0]];
        int darabSzam = int.Parse(adatsor[1]);
        if ( jatek is null)
        {
            File.AppendAllText("hibalista.txt", $"{adatsor[0]}: Ilyen azonosítójú játékot nem gyártanak.\n");
        }
        else
        {
            Feladat? feladat = null;
            try 
            {                 
                feladat = new Feladat(jatek, darabSzam);
            }
            catch (TulSokFeladatException ex)
            {
                File.AppendAllText("hibalista.txt", $"{ex.Message} - {darabSzam} db {jatek.Megnevezes}: {jatek.ElkeszitesiIdo*darabSzam} perc\n");
            }
            if (feladat is not null) yield return feladat;
        }
    }
}

Feladatok FeladatHozzaadas()
{
    Feladatok feladatok = new();
    foreach (var feladat in FeladatokBeolvasas("feladatok.txt"))
    {
        feladatok += feladat;
    }
    return feladatok;
}