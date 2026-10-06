namespace Darts_lib
{
    public class Dobas
    {
        public int Player { get; init; }
        public string Elso { get; init; }
        public string Masodik { get; init; }
        public string Harmadik { get; init; }
        public Dobas(string[] sor)
        {
            Player = int.Parse(sor[0]);
            Elso = sor[1];
            Masodik = sor[2];
            Harmadik = sor[3];
        }
    }
}
