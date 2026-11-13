using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Szepseg_lib
{
    public class DataStore
    {
        public Alkalmazottak alkalmazottak {  get; init; }
        public Kezelesek kezelesek { get; init; }
        public Vendegek vendegek { get; init; }
        public Szakmak szakmak {  get; init; }
        public DataStore(IEnumerable<string> fajlok)
        {
            List<Alkalmazott> alk = new();
            List<Kezeles> kez = new();
            List<Szakma> szak = new();
            List<Vendeg> ven = new();
            foreach (string fajlNev in fajlok)
            {
                string[] fajl = File.ReadAllLines(fajlNev+".csv");
                List<string> adatok = new();
                foreach(string sor in fajl.Skip(1))
                {
                    adatok.AddRange(sor.Split(";"));
                }
                switch (fajlNev)
                {
                    case "alkalmazottak":
                        alk.Add(new Alkalmazott(int.Parse(adatok[0]), adatok[1], int.Parse(adatok[2]), adatok[3]));
                        break;
                    case "kezelesek":
                        kez.Add(new Kezeles(int.Parse(adatok[0]), int.Parse(adatok[1]), int.Parse(adatok[2]), adatok[3], TimeOnly.Parse(adatok[4]), int.Parse(adatok[5])));
                        break;
                    case "szakmak":
                        szak.Add(new Szakma(int.Parse(adatok[0]), adatok[1]));
                        break;
                    case "vendegek":
                        ven.Add(new Vendeg(int.Parse(adatok[0]), adatok[1], adatok[2], adatok[3]));
                        break;
                    default: 
                        break;
                }
            }
            alkalmazottak = new Alkalmazottak(alk);
            kezelesek = new Kezelesek(kez);
            szakmak = new Szakmak(szak);
            vendegek = new Vendegek(ven);
        }
    }
}
