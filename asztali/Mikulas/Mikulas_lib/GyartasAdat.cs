namespace Mikulas_lib
{
    public class GyartasAdat
    {
        //Azonosito;Tipus;ElkeszitesiIdo
        public string Azonosito { get; init; }
        public string Tipus { get; init; }
        public int ElkeszitesiIdo { get; init; }
        public GyartasAdat(string sor)
        {
            var adatok = sor.Split(';');
            Azonosito = adatok[0];
            Tipus = adatok[1];
            ElkeszitesiIdo = int.Parse(adatok[2]);
        }
    }
}
