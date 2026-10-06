namespace Forma_1_Lib
{
    public class Versenyzo
    {
        public DateOnly Date { get; init; }
        public string Location { get; init; }
        public string Name { get; init; }
        public string Gender { get; init; }
        public DateOnly? BirthDate { get; init; }
        public string Country { get; init; }
        public string? Place { get; init; }
        public string? Mistake { get; init; }
        public string? Team { get; init; }
        public string Type { get; init; }
        public string EngineType { get; init; }
        public Versenyzo(string[] row)
        {
            Date = DateOnly.Parse(row[0]);
            Location = row[1];
            Name = row[2];
            Gender = row[3];
            BirthDate = DateNullable(row[4]);
            Country = row[5];
            Place = StringNullable(row[6]);
            Mistake = StringNullable(row[7]);
            Team = StringNullable(row[8]);
            Type = row[9];
            EngineType = row[10];
        }
        string? StringNullable(string text)=> string.IsNullOrEmpty(text) ? null : text;
        DateOnly? DateNullable(string text)=> string.IsNullOrEmpty(text) ? null : DateOnly.Parse(text);


    }
}
