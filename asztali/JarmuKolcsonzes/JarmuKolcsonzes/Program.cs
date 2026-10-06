using JarmuKolcsonzes_lib;

List<Jarmu> jarmuvek = new List<Jarmu>();
Random rnd = new Random();

foreach (string sor in File.ReadAllLines("jarmu.csv"))
{
    jarmuvek.Add(JarmuFactory.Factory(sor));
}

foreach (Jarmu jarmu in jarmuvek)
{
    Console.WriteLine("\n" + jarmu);

    for (int i = 0; i < 5; i++)
    {
        int eleje = rnd.Next(-1, 32);
        int vege = eleje + rnd.Next(-2, 10);

        Console.WriteLine($"Próba intervallum: {eleje} - {vege}");

        try
        {
            if (jarmu.Kolcsonzes(eleje, vege))
            {
                int napokSzama = vege - eleje + 1;
                int fizetendo = jarmu.FizetendoAr(napokSzama);

                Console.WriteLine("Sikeres kölcsönzés");
                Console.WriteLine($"Fizetendő összeg: {fizetendo} Ft");
                Console.WriteLine("Jármű aktuális állapota:");
                Console.WriteLine(jarmu);
            }
            else
            {
                Console.WriteLine("Sikertelen kölcsönzés (nem volt végig szabad)");
            }
        }
        catch (HibasIntervallumException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

Console.WriteLine("Program vége.");