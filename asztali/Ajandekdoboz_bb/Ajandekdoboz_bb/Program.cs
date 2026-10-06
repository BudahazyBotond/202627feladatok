using Ajandekdoboz_lib;
Main();
void Main()
{
    Console.WriteLine("Milyen ajándékdobozt szeretnél összeállítani? (bor/kozmetika/édesség/hús)");
    string valasz = Console.ReadLine()!.ToLower();
    switch (valasz)
    {
        case "bor":
            BorMain();
            break;
        case "kozmetika":
            KozmetikaMain();
            break;
        case "édesség":
            EdessegMain();
            break;
        case "hús":
            FustoltHusMain();
            break;
        default:
            Console.WriteLine("Érvénytelen választás, kérlek próbáld újra.");
            Main();
            return;
    }
}
void BorMain()
{
    Console.Write("Add meg a csomag nevét: ");
    string csomagNev = Console.ReadLine()!;
    AjandekDoboz<Bor> borCsomag = new AjandekDoboz<Bor>(csomagNev, TermekTipusok.TermekTipus.Bor);
    Console.Write("Hány terméket szeretnél hozzáadni a csomaghoz? ");
    int termekDb = int.Parse(Console.ReadLine()!);
    if (termekDb < 1)
    {
        Console.WriteLine("Legalább egy terméket hozzá kell adni a csomaghoz.");
        BorMain();
    }
    else for (int i = 0; i <= termekDb-1; i++)
    {
        Console.Write($"Add meg a(z) {i + 1}. bor nevét: ");
        string borNev = Console.ReadLine()!;
        Console.Write($"Add meg a(z) {i + 1}. bor árát: ");
        int borAr = int.Parse(Console.ReadLine()!);
        Console.Write($"Add meg a(z) {i + 1}. bor alkoholtartalmát (%): ");
        double alkoholSzazalek = double.Parse(Console.ReadLine()!);
        Bor ujBor = new Bor(borNev, borAr, alkoholSzazalek);
        borCsomag.UjTermek(ujBor);
    }
    Console.WriteLine(borCsomag.ToString());
}
void KozmetikaMain()
{
    Console.Write("Add meg a csomag nevét: ");
    string csomagNev = Console.ReadLine()!;
    AjandekDoboz<Kozmetikum> KozmetikumCsomag = new AjandekDoboz<Kozmetikum>(csomagNev, TermekTipusok.TermekTipus.Kozmetikum);
    Console.Write("Hány terméket szeretnél hozzáadni a csomaghoz? ");
    int termekDb = int.Parse(Console.ReadLine()!);
    if (termekDb < 1)
    {
        Console.WriteLine("Legalább egy terméket hozzá kell adni a csomaghoz.");
        KozmetikaMain();
    }
    else for (int i = 0; i <= termekDb - 1; i++)
    {
        Console.Write($"Add meg a(z) {i + 1}. termék nevét: ");
        string kozmetikaNev = Console.ReadLine()!;
        Console.Write($"Add meg a(z) {i + 1}. termék árát: ");
        int kozmetikaAr = int.Parse(Console.ReadLine()!);
        Console.Write($"Allergénmentes a(z) {i + 1}. termék (i/n)? ");
        bool allergenMentes = false;
            if (Console.ReadLine()! == "i") allergenMentes = true;
        Console.WriteLine($"Állatokon tesztelt a(z) {i + 1}. termék (i/n)? ");
        bool allatokonTesztelt = false;
            if (Console.ReadLine()! == "i") allatokonTesztelt = true;
        Kozmetikum ujKozmetika = new Kozmetikum(kozmetikaNev, kozmetikaAr, allergenMentes, allatokonTesztelt);
        KozmetikumCsomag.UjTermek(ujKozmetika);
    }
    Console.WriteLine(KozmetikumCsomag.ToString());
}
void EdessegMain()
{
    Console.Write("Add meg a csomag nevét: ");
    string csomagNev = Console.ReadLine()!;
    AjandekDoboz<Edesseg> edessegCsomag = new AjandekDoboz<Edesseg>(csomagNev, TermekTipusok.TermekTipus.Edesseg);
    Console.Write("Hány terméket szeretnél hozzáadni a csomaghoz? ");
    int termekDb = int.Parse(Console.ReadLine()!);
    if (termekDb < 1)
    {
        Console.WriteLine("Legalább egy terméket hozzá kell adni a csomaghoz.");
        EdessegMain();
        
    }
    else for (int i = 0; i <= termekDb - 1; i++)
    {
        Console.Write($"Add meg a(z) {i + 1}. édesség nevét: ");
        string edessegNev = Console.ReadLine()!;
        Console.Write($"Add meg a(z) {i + 1}. édesség árát: ");
        int edessegAr = int.Parse(Console.ReadLine()!);
        Console.Write($"Add meg a(z) {i + 1}. édesség cukortartalmát 100 grammonként (g): ");
        int cukorPer100g = int.Parse(Console.ReadLine()!);
        Edesseg ujEdesseg = new Edesseg(edessegNev, edessegAr, cukorPer100g);
        edessegCsomag.UjTermek(ujEdesseg);
    }
    Console.WriteLine(edessegCsomag.ToString());
}
void FustoltHusMain()
{
    Console.Write("Add meg a csomag nevét: ");
    string csomagNev = Console.ReadLine()!;
    AjandekDoboz<FustoltHus> husCsomag = new AjandekDoboz<FustoltHus>(csomagNev, TermekTipusok.TermekTipus.FustoltHus);
    Console.Write("Hány terméket szeretnél hozzáadni a csomaghoz? ");
    int termekDb = int.Parse(Console.ReadLine()!);
    if (termekDb < 1)
    {
        Console.WriteLine("Legalább egy terméket hozzá kell adni a csomaghoz.");
        EdessegMain();

    }
    else for (int i = 0; i <= termekDb - 1; i++)
        {
            Console.Write($"Add meg a(z) {i + 1}. füstölt hús nevét: ");
            string husNev = Console.ReadLine()!;
            Console.Write($"Add meg a(z) {i + 1}. füstölt hús árát: ");
            int husAr = int.Parse(Console.ReadLine()!);
            Console.Write($"Add meg a(z) {i + 1}. füstölt hús minőségét(pl. prémium) vagy fajtáját(pl. hagyományos/artisanal): ");
            string fajtaMinoseg = Console.ReadLine()!;
            FustoltHus ujHus = new FustoltHus(husNev, husAr, fajtaMinoseg);
            husCsomag.UjTermek(ujHus);
        }
    Console.WriteLine(husCsomag.ToString());
}

