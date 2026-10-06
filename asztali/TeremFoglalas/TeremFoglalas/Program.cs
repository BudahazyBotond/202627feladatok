using System.Runtime.CompilerServices;
using TeremFoglalas_lib;

//hibalista frissítése
File.Delete("hibalista.txt");


TeremNyilvantartas termek = new TeremNyilvantartas(
    TeremekBeolvasasaFajlbol("termek.txt", 1)
    );
List<Foglalas> foglalasok = FoglalasokBeolvasasaFajlbol(
    "foglalasok.txt", 1).ToList();

Console.WriteLine("Az elérhető termek: ");
foreach(var teremAzonosito in termek.TeremAzonositok)
{
    Console.WriteLine(teremAzonosito);
}

Console.WriteLine("A termek a foglalások után:");
termek.TeremFoglalasok(foglalasok);
Console.WriteLine("Foglalt időpontok:");
foreach(var terem in termek.Termek)
{
    Console.WriteLine(terem);
}

Console.Write("Kérem egy tanár azonosítóját: ");

string megadottAzonosito = Console.ReadLine()!;

Console.WriteLine("A tanár foglalásai:");
foreach(var elem in termek.FoglalasokTanarAzonositoAlapjan(megadottAzonosito))
{
    Console.WriteLine(elem.Key);
    foreach(var idoPont in elem.Value)
    {
        Console.WriteLine(idoPont);
    }
}




//TeremTipus;TeremAzonosito;HelyekSzama;TakaritasiIdo
IEnumerable<Terem> TeremekBeolvasasaFajlbol(string fajlnev, int kihagyas)
{
    List<Terem> termek = new List<Terem>();
    foreach (var sor in File.ReadAllLines(fajlnev).Skip(kihagyas))
    {
        termek.Add(TeremKeszito.Teremkeszites(sor));
    }
    return termek;
}

IEnumerable<Foglalas> FoglalasokBeolvasasaFajlbol(string fajlnev, int kihagyas)
{
    List<Foglalas> foglalasok = new List<Foglalas>();
    foreach (var sor in File.ReadAllLines(fajlnev).Skip(kihagyas))
    {
        Foglalas? foglalas = FoglalasBeolvasasSorbol(sor);
        if (foglalas is not null)
        {
            foglalasok.Add(foglalas);
        }
    }
    return foglalasok;
}

//Kezdet;IdotartamPercben;Terem;Tanar
Foglalas? FoglalasBeolvasasSorbol(string sor)
{
    Foglalas? foglalas = null;
    try
    {
        string[] adatok = sor.Split(";");
        int idoTartam = int.Parse(adatok[1]);

        foglalas =  new Foglalas(
                DateTime.Parse(adatok[0]),
                idoTartam,
                adatok[2],
                adatok[3]
                );
    }
    catch(IdoTartamException ex)
    {
        File.AppendAllText("hibalista.txt", $"{sor} - {ex.Message}\n");
    }
    return foglalas;
}