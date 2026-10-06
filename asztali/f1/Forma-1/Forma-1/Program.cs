using Forma_1_Lib;
using System.ComponentModel;

Versenyzok list = new Versenyzok(File.ReadAllLines("eredmenyek.csv"));
Console.WriteLine($"2. feladat: Hill vezetéknevűek:");
foreach (var item in list.Hills())
{
    Console.WriteLine($"\t{item.Name} ({item.Country}) {item.BirthDate}");
}
Console.WriteLine($"3. feladat: futamgyőztesek:");
foreach (var item in list.Winners())
{
    Console.WriteLine($"\t{item.Name}");
}
Console.WriteLine($"4. feladat: Juan-Manuel Fangio {list.FirstRace("Juan-Manuel Fangio").Date.Year-list.FirstRace("Juan-Manuel Fangio").BirthDate.Value.Year} éves volt az első versenyén");
Console.WriteLine($"5. feladat: Ferrariknál a 3 leggyakoribb hiba:");
foreach (var item in list.Top3MistakesOfFerrari())
{
    Console.WriteLine($"\t{item.Key}: {item.Value} eset");
}
Console.WriteLine($"6. feladat: {list.NoTeam()} olyan versenyző volt, akiknek valamelyik versenyén nem volt csapata");
Console.WriteLine($"7. feladat: Magyarország után rendezték az első nagydíjukat: {string.Join(",",list.CountryAfterHungary("Monaco"))}");// nincs MO a fájlban
list.WriteFile("monaco.txt", "Monaco");