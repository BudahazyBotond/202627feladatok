using System;
using System.Collections.Generic;
using System.Text;

namespace Lovaglas_lib
{
    public class Datastore
    {
        public List<Kepzes> Kepzesek { get; init; } = new();
        public List<Oktato> Oktatok { get; init; } = new();
        public List<Orarend> Orarendek { get; init; } = new();
        public List<Szint> Szintek { get; init; } = new();
        public Datastore(List<string> fileNames)
        {
            foreach (string fileName in fileNames)
            {
                if (!File.Exists(fileName+".csv")) break;
                string[] file;
                switch(fileName)
                {
                    case "kepzes":
                        file = File.ReadAllLines(fileName+".csv");
                        foreach (string line in file.Skip(1))
                        {
                            string[] datas = line.Split(";");
                            Kepzesek.Add(new Kepzes(int.Parse(datas[0]), datas[1], int.Parse(datas[2])));
                        }
                        break;
                    case "oktato":
                        file = File.ReadAllLines(fileName + ".csv");
                        foreach (string line in file.Skip(1))
                        {
                            string[] datas = line.Split(";");
                            Oktatok.Add(new Oktato(int.Parse(datas[0]), datas[1], datas[2], datas[3], int.Parse(datas[4])));
                        }
                        break;
                    case "orarend":
                        file = File.ReadAllLines(fileName + ".csv");
                        foreach (string line in file.Skip(1))
                        {
                            string[] datas = line.Split(";");
                            Orarendek.Add(new Orarend(int.Parse(datas[0]), DateOnly.Parse(datas[1]), TimeOnly.Parse(datas[2]), int.Parse(datas[3]), int.Parse(datas[4]), int.Parse(datas[5]), int.Parse(datas[6]), datas[7], int.Parse(datas[8])));
                        }
                        break;
                    case "szint":
                        file = File.ReadAllLines(fileName + ".csv");
                        foreach (string line in file.Skip(1))
                        {
                            string[] datas = line.Split(";");
                            Szintek.Add(new Szint(int.Parse(datas[0]), datas[1], datas[2], datas[3]));
                        }
                        break;
                }
            }
        }
        public int Bevetel(int id)
        {
            double bevetel = 0;
            double percdij = Oktatok.Where(x=>x.OktatoId == id).First().Oradij / 60;
            List<Orarend> relevansOrarendek = Orarendek.Where(x => x.OktatoId == id).ToList();
            foreach(Orarend ora  in relevansOrarendek)
            {
                bevetel += percdij * ora.Hossz * ora.Letszam;
            }
            return (int)Math.Round(bevetel,0);
        }
        public int Legalabb45p()
        {
            return Orarendek.Count(x => x.Hossz >= 45);
        }
        public string AdatokNevbol(string nev)
        {
            Oktato? okt = Oktatok.Where(x => x.Nev == nev).FirstOrDefault();
            return okt == null ? "\tIlyen néven nem található oktató!" 
                : $"\tEmail: {okt.Email}\n\tTelefon: {okt.Telefon}";
        }
        public List<Oktato> KepzesSzerint(string kepzes)
        {
            int kepzesId = Kepzesek.Where(x=>x.KepzesTipus == kepzes).FirstOrDefault().KepzesId;
            List<Orarend> relevansOrak = Orarendek.Where(x => x.KepzesId == kepzesId).ToList();
            List<Oktato> oktatok = new();
            int[] relevansIdk = relevansOrak.Select(x=>x.OktatoId).Distinct().ToArray();
            foreach(int id in relevansIdk)
            {
                oktatok.Add(Oktatok.Where(x=>x.OktatoId == id).FirstOrDefault());
            }
            return oktatok;
        }
    }
}
