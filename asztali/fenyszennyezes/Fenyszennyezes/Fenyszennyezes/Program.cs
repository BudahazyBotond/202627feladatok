using Fenyszennyezes;
var terkep = new Fenyterkep("terkep.txt");

Console.WriteLine("2. feladat:");
Console.Write("A mérés sorának azonosítója: ");
int sor = int.Parse(Console.ReadLine()!);
Console.Write("A mérés oszlopának azonosítója: ");
int oszlop = int.Parse(Console.ReadLine()!);
Console.WriteLine($"Az adott helyen {terkep[sor - 1, oszlop - 1]} a mért fényesség értéke.\n");

Console.WriteLine("3. feladat:");
double szazalek = terkep.SotetSzazalek();
Console.WriteLine($"A terület {szazalek:0.0} %-a teljesen sötét.\n");

Console.WriteLine("4. feladat:");
var legfenyesebb = terkep.Legfenyesebb();
Console.WriteLine($"A legnagyobb fényességérték: {legfenyesebb.MaxErtek}");
Console.WriteLine("A legfényesebb helyek koordinátái:");
legfenyesebb.Koordinatak.ForEach(k => Console.Write($"({k.Sor}, {k.Oszlop}) "));
Console.WriteLine("\n");

Console.WriteLine("5. feladat:");
var fenyesPontok = terkep.FenyesPontok();
Console.WriteLine($"A fényes területek száma: {fenyesPontok.Count} db.\n");

Console.WriteLine("6. feladat:");
var teglalap = terkep.Befoglalo(fenyesPontok);
if (teglalap.HasValue)
{
    var t = teglalap.Value;
    Console.WriteLine("A legkisebb téglalap, amely az összes fényes pontot tartalmazza:");
    Console.WriteLine($"bal-felső: ({t.BalFelso.Sor}, {t.BalFelso.Oszlop}), jobb-alsó: ({t.JobbAlso.Sor}, {t.JobbAlso.Oszlop})\n");
}

Console.WriteLine("7. feladat:");
Console.Write("A vizsgált oszlop sorszáma: ");
int diagramOszlop = int.Parse(Console.ReadLine()!);
terkep.Diagram(diagramOszlop - 1, "diagram.txt");
