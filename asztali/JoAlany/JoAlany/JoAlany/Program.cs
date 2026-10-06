using JoAlany_lib;

Nyilvantartas people = new Nyilvantartas(File.ReadAllLines("input.txt"));

foreach (var person in people.AllPerson)
{
    try
    {
        Console.WriteLine(person.ToString()); ;
    }
    catch
    {
        throw new Exception();
    }
}

Console.WriteLine($"Diákok száma: {people.StundetsCount}");
Console.WriteLine($"Tanárok száma: {people.TeachersCount}");
Console.WriteLine($"Tanárok átlagos életkora: {people.AvarageAgeOfTeachers}");

foreach (var cheaters in people.StudentsAndCheatsDict)
{
    Console.WriteLine($"{cheaters.Key} db puskázás: {string.Join(", ", cheaters.Value)}");
}


