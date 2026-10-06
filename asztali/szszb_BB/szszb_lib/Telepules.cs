namespace szszb_lib
{
    public class Telepules
    {
        public readonly string nev;
        public readonly string rang;
        public readonly string terseg;
        public readonly int terulet;
        public readonly int lakossag;
        public readonly double nepsuruseg;
        public Telepules(string[] sor)
        {
            nev = sor[0];
            rang = sor[1];
            terseg = sor[2];
            terulet = int.Parse(sor[3]);
            lakossag = int.Parse(sor[4]);
            nepsuruseg = (double)lakossag*100 / terulet;
        }
    }
}
