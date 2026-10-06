using System;

namespace MesterEmberLib
{
    public static class MesterFactory
    {
        public static MesterEmber Factory(string adatsor)
        {
            var adatok = adatsor.Split(';');

            if (adatok.Length < 3)
            {
                throw new ArgumentException("Hibás adatsor formátum!");
            }

            string tipus = adatok[0].Trim();
            string nev = adatok[1].Trim();

            switch (tipus.ToLower())
            {
                case "b":
                    if (adatok.Length < 4)
                    {
                        throw new ArgumentException("Burkolóhoz szükséges mind a 4 adat!");
                    }
                    int napidij = int.Parse(adatok[2].Trim());
                    string szakterulet = adatok[3].Trim().ToLower();
                    return new Burkolo(nev, napidij, szakterulet);

                case "v":
                    int tapasztalat = int.Parse(adatok[2].Trim());
                    return new VizvezetekSzerelo(nev, tapasztalat);

                default:
                    throw new ArgumentException($"Ismeretlen mester típus: {tipus}");
            }
        }
    }
}