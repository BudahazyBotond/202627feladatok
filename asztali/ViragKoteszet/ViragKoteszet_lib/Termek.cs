using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public class Termek : ITermek
    {
        public int Id { get; init; }

        public string Tipus { get; init; }

        public string Megnevezes { get; init; }


        public Dictionary<string, int> AlapanyagokEsSzamuk { get; init; }
        private readonly Katalogus katalogus;

        public Termek(int id, string tipus, string megnevezes, Dictionary<string, int> alapanyagokEsSzamuk, Katalogus katalogus)
        {
            Id = id;
            Tipus = tipus;
            Megnevezes = megnevezes;
            this.katalogus = katalogus;
            AlapanyagokEsSzamuk = alapanyagokEsSzamuk;
        }
        public int ElkeszitesiIdo
        {
            get
            {
                int sum = 0;
                foreach (var elem in AlapanyagokEsSzamuk)
                {
                    try
                    {
                        sum += elem.Value * katalogus[elem.Key]!.ElkeszitesiIdo;
                    }
                    catch
                    {
                        throw new ArgumentNullException();
                    }
                }
                return sum;
            }
        }
        public int Ar
        {
            get
            {
                int sum = 0;
                foreach (var elem in AlapanyagokEsSzamuk)
                {
                    try
                    {
                        sum += elem.Value * katalogus[elem.Key]!.Ar;
                    }
                    catch
                    {
                        throw new ArgumentNullException();
                    }
                }
                return sum;
            }
        }
        public override string ToString()
        {
            string szoveg = $"{Id}; {Tipus}; {Megnevezes};";
            string[] szovegek = new string[AlapanyagokEsSzamuk.Count];
            int indexer = 0;
            foreach(var elem in AlapanyagokEsSzamuk)
            {
                szovegek[indexer] = ($"{elem.Key}({elem.Value})");
                indexer++;
            }
            szoveg += string.Join(", ", szovegek);
            return szoveg;
        }
    }
}
