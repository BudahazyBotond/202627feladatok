using ViragKoteszet_lib;

Katalogus katalogus = KatalogusKeszitesFajlbol("alapanyagok.txt", 1);
Dolgozok dolgozok = DolgozokBeolvasasaFajlbol("dolgozok.txt", 1);
Termekek termekek = TermekekBeolvasasaFajlbol("termekek.txt", 1, katalogus);
FeladatKiosztasFajlbol(dolgozok, termekek, "feladatkiosztas.txt", 1);

Console.WriteLine("Elkészíthető termékek:");
Console.WriteLine(termekek.ToString());

foreach (Dolgozo dolgozo in dolgozok.OsszesDolgozo)
{
    Console.WriteLine(dolgozo.ToString() + " percet dolgozott.");
}

Katalogus KatalogusKeszitesFajlbol(string fajlNev, int kihagyas)
{
    List<Alapanyag> alapanyagok = new List<Alapanyag>();
    foreach (string sor in File.ReadAllLines(fajlNev).Skip(kihagyas))
    {
        string[] adatok = sor.Split(';');
        alapanyagok.Add(new Alapanyag(
            adatok[0],
            adatok[1],
            int.Parse(adatok[2]),
            int.Parse(adatok[3])
            ));
    }
    return new Katalogus(alapanyagok);
}
Dolgozok DolgozokBeolvasasaFajlbol(string fajlNev, int kihagyas)
{
    Dolgozok dolgozok = new Dolgozok();
    foreach (string sor in File.ReadAllLines(fajlNev).Skip(kihagyas))
    {
        dolgozok.Dolgozofelvetel(MunkaeroFelvetel.MunkaeroKeszites(
            sor
            ));
    }
    return dolgozok;
}
void FeladatKiosztasFajlbol(Dolgozok dolgozok, Termekek termekek,
    string fajlNev, int kihagyas)
{
    foreach (string sor in File.ReadAllLines(fajlNev).Skip(kihagyas))
    {
        string[] adatok = sor.Split(';');
        FeladatKiosztas.FeladatKiosztasa(
            dolgozok, termekek,
            int.Parse(adatok[0]), int.Parse(adatok[1])
            );
    }
}
Termekek TermekekBeolvasasaFajlbol(string fajlNev, int kihagyas, Katalogus katalogus)
{
    Termekek termekek = new Termekek();
    foreach (string sor in File.ReadAllLines(fajlNev).Skip(kihagyas))
    {
        Dictionary<string, int> szotar = new Dictionary<string, int>();
        string[] adatok = sor.Split(';');
        string segedValtozo = "";
        for (int i = 3; i < adatok.Length; i++)
        {
            if (i % 2 == 1)
            {
                segedValtozo = adatok[i];
            }
            else
            {
                szotar.Add(segedValtozo, int.Parse(adatok[i]));
            }
        }
        termekek.Termekfelvetel(new Termek(
        int.Parse(adatok[0]),
        adatok[1],
        adatok[2],
        szotar,
        katalogus
        ));
    }
    return termekek;
}