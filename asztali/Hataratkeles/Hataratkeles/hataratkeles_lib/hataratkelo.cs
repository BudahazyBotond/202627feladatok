namespace Hataratkeles_lib
{
    public class Hataratkelo
    {
        public string TelepulesNev {  get; init; }
        public string TelepulesTipus { get; init; }
        public string Megye { get; init; }
        public string SzomszedTelepules { get; init; }
        public string Orszag { get; init; }
        public string AtkeloTipus { get; init; }
        public Hataratkelo(string[] sor)
        {
            this.TelepulesNev = sor[0];
            this.TelepulesTipus = sor[1];
            this.Megye = sor[2];
            this.SzomszedTelepules = sor[3];
            this.Orszag = sor[4];
            this.AtkeloTipus = sor[5];
        }
    }
}
