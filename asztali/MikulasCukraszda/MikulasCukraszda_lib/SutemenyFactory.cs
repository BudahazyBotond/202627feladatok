namespace MikulasCukraszda_lib
{
    public class SutemenyFactory
    {
        KeszitesiAdatok KeszitesiAdatok { get; set; }
        public Sutemeny Factory(string sor, KeszitesiAdatok keszitesiAdatok)
        {
            string[] adatok = sor.Split(';');
            string azonosito = adatok[0];
            string tipus = adatok[1];
            string megnevezes = adatok[2];
            string[] diszitesek = adatok[3..];

            if (tipus.StartsWith("f"))
            {
                return new DiszitettSutemeny(azonosito, tipus, megnevezes, KeszitesiAdatok, diszitesek);
            }
            else
            {
                return new AlapSutemeny(azonosito, tipus, megnevezes, KeszitesiAdatok);
            }
        }
    }
}
