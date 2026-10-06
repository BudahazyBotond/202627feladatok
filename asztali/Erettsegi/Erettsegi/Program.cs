// 2024 okt érettségi adatbázis txt állományokat használok
// 3 adatokkal számoló feladat pipa
// 2 számított tulajdonság pipa
// 1 csoportosításos feladat pipa
// 1 feladat két forrásfájlból pipa
using Erettsegi_lib;
Erettsegik erettsegik = new Erettsegik("tanar.txt", "vizsgak.txt", "vizsgazo.txt");
Console.Write("Adjon meg, hogy miből szeretné megtudni, hogy mennyi van (tanár/vizsga/vizsgázó): ");
string tárgy = Console.ReadLine()!;
if(tárgy.Length > 0)
{
    Console.WriteLine($"{erettsegik.ListDb(tárgy)}db {tárgy} van.\n");
}
Console.Write("Adjon meg egy osztályt (évfolyam/osztály): ");
string osztaly = Console.ReadLine()!;
if(osztaly.Length > 2)
{
    Console.WriteLine($"Az érettségizők {erettsegik.OsztalySzazalek(osztaly).Item1}%-a ({erettsegik.OsztalySzazalek(osztaly).Item2}db) a(z) {osztaly} osztály tagja.");
}
Console.WriteLine("\nA vizsgatárgyankénti vizsgák darabszáma:");
foreach (var (targy, darab) in erettsegik.TargyankentDb())
{
    Console.WriteLine($"{targy}: {darab} db vizsga");
}
Console.Write($"\nAdja meg egy tanuló nevét: ");
string tanulo = Console.ReadLine()!;
if (tanulo.Length > 0)
{
    Console.WriteLine($"{tanulo}: {string.Join(", ",erettsegik.TanuloVizsgatargyai(tanulo))}");
}
