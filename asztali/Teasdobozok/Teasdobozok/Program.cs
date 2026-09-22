using Teasdobozok_lib;

string[] fileFilterek = File.ReadAllLines("filterek.txt");
string[] fileDobozok = File.ReadAllLines("dobozok.txt");

List<Filter> filter = new List<Filter>();
for (int i = 1; i < fileFilterek.Length; i++)
{
    string[] data = fileFilterek[i].Split(';');
    filter.Add(new Filter(data[0], data[1], int.Parse(data[2])));
}
Filterek filterek = new Filterek(filter);
Console.WriteLine("Elérhető gyógynövény filterek:");
foreach (var gyogytea in filterek.GyogynovenyFilterek)
{
    Console.WriteLine(filterek[gyogytea].ToString());
}

Console.WriteLine("\nElkészített teásdobozok:");
List<TeasDoboz> dobozok = new List<TeasDoboz>();
File.Delete("error.txt");
foreach (var sor in fileDobozok.Skip(1))
{
    try
    {
        dobozok.Add(DobozFactory.Factory(sor, filterek));
    }
    catch (Exception ex)
    {
        File.AppendAllText("error.txt", $"{ex.Message}\n");
    }
}
foreach (var doboz in dobozok)
{
    Console.WriteLine(doboz.ToString());
}