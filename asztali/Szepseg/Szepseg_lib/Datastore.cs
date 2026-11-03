using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szepseg_lib
{
    public class Datastore
    {
        public Alkalmazottak AlkalmazottakList { get; init; } = new([]);
        public Kezelesek KezelesekList { get; init; } = new([]);
        public Szakmak SzakmakList { get; init; } = new([]);
        public Vendegek VendegekList { get; init; } = new([]);
        public Datastore(List<string> fileNames)
        {
            List<Alkalmazott> alkTemp = new();
            List<Kezeles> kezTemp = new();
            List<Szakma> szakTemp = new();
            List<Vendeg> venTemp = new();
            foreach (string fileName in fileNames)
            {
                if (!File.Exists(fileName + ".csv")) break;
                string[] file;
                switch (fileName)
                {
                    case "alkalmazottak":
                        file = File.ReadAllLines(fileName+".csv");
                        foreach (string line in file.Skip(1))
                        {
                            string[] adatok = line.Split(';');
                            alkTemp.Add(new Alkalmazott(int.Parse(adatok[0]), adatok[1], int.Parse(adatok[2]), adatok[3]));
                        }
                        AlkalmazottakList = new Alkalmazottak(alkTemp);
                        break;
                    case "kezelesek":
                        file = File.ReadAllLines(fileName + ".csv");
                        foreach (string line in file.Skip(1))
                        {
                            string[] adatok = line.Split(';');
                            kezTemp.Add(new Kezeles(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[2]), DateOnly.Parse(adatok[3]), TimeOnly.Parse(adatok[4]), int.Parse(adatok[5])));
                        }
                        KezelesekList = new Kezelesek(kezTemp);
                        break;
                    case "szakmak":
                        file = File.ReadAllLines(fileName + ".csv");
                        foreach (string line in file.Skip(1))
                        {
                            string[] adatok = line.Split(';');
                            szakTemp.Add(new Szakma(int.Parse(adatok[0]), adatok[1]));
                        }
                        SzakmakList = new Szakmak(szakTemp);
                        break;
                    case "vendegek":
                        file = File.ReadAllLines(fileName + ".csv");
                        foreach (string line in file.Skip(1))
                        {
                            string[] adatok = line.Split(';');
                            venTemp.Add(new Vendeg(int.Parse(adatok[0]), adatok[1], adatok[2], adatok[3]));
                        }
                        VendegekList = new Vendegek(venTemp);
                        break;
                    default:
                        break;

                }
            }
        }
        public int Bevetel(string nev)
        {
            return KezelesekList.Bevetel(AlkalmazottakList[nev].AlkalmazottId);
        }
        public string Top3()
        {
            int[] ids = KezelesekList.Top3Id();
            string[] nevek = AlkalmazottakList.Nevek(ids);
            string sb = $"\t{nevek[0]} ({SzakmakList[AlkalmazottakList[nevek[0]].SzakmaId].Nev}): {Bevetel(nevek[0])}Ft\n" +
                $"\t{nevek[1]} ({SzakmakList[AlkalmazottakList[nevek[1]].SzakmaId].Nev}): {Bevetel(nevek[1])}Ft\n" +
                $"\t{nevek[2]} ({SzakmakList[AlkalmazottakList[nevek[2]].SzakmaId].Nev}): {Bevetel(nevek[2])}Ft";
            return sb;
        }
    


}
}
