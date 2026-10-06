using indexer;
#region Romai
Romai romai = new Romai();
for (int i = 0; i < 12; i++)
{
    Console.WriteLine($"{romai[i]}");
}
#endregion
#region Sakk
SakkTabla sakk = new();
List<char> betuk = new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

for (int i = 8; i >= 1; i--)
{
    Console.Write($"{i} ");
    foreach (var item in betuk)
    {
        Console.Write(sakk[item, i]);
    }
    Console.WriteLine();
}
Console.WriteLine($"  {String.Join("", betuk)}");
#endregion
#region Tarolo
Tarolo tarolo = new();
for (int i = 0; i < 100; i++)
{
    tarolo.Add(i * i);
}

tarolo[5] = 42;

for (int i = 0; i < tarolo.Count; i++)
{
    Console.WriteLine(tarolo[i]);
}

try
{
    Console.WriteLine(tarolo[150]);
}
catch (Exception ex)
{
    Console.WriteLine($"Exception jött: {ex}");
}
#endregion