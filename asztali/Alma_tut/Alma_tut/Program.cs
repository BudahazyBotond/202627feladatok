using Alma_tut;
using System.Text.Json;

ISzimulaci szimulacio;
string fajlnev = "alma.json";
try
{
    szimulacio = JsonSerializer.Deserialize<Alma>(File.ReadAllText(fajlnev))!;
}
catch (Exception)
{
    szimulacio = new Alma();
}
ConsoleKey keyChar;
do
{
    szimulacio.Kor();
    Console.Clear();
    Console.WriteLine(szimulacio.ToString());
    Thread.Sleep(100);
    keyChar = Console.ReadKey().Key;
}
while (keyChar != ConsoleKey.Escape && szimulacio.EletbenVan);
if (szimulacio.EletbenVan)
{
    File.WriteAllText(fajlnev, JsonSerializer.Serialize <Alma>((szimulacio as Alma)!));
}
else
{
    {
        if (File.Exists(fajlnev))
        {
            File.Delete(fajlnev);
        }
    }
}
