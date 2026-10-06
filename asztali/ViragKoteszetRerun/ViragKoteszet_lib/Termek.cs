using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    internal class Termek : ITermek
    {
        public string Tipus { get; init; }

        public string Megnevezes { get; init; }

        public int ElkeszitesiIdo { 
            get
            {
                int ido = 0;
                foreach (var item in _alapanyagok)
                {
                    ido += item.Value * _katalogus[item.Key]!.ElkeszitesiIdo;
                }
                return ido;
            }
        }

        public int Ar
        {
            get
            {
                int ar = 0;
                foreach (var item in _alapanyagok)
                {
                    ar += item.Value * _katalogus[item.Key]!.Ar;
                }
                return ar;
            }
        }

        private Dictionary<string, int> _alapanyagok { get; init; }
        private Katalogus _katalogus { get; init; }

        //ID;Tipus;Megnevezes;Alapanyagok
        public Termek(string tipus, string megnevezes, Dictionary<string, int> alapanyagok, Katalogus katalogus)
        {
            Tipus = tipus;
            Megnevezes = megnevezes;
            _alapanyagok = alapanyagok;
            _katalogus = katalogus;
        }

        public override string ToString()
        {
            return $"Név: {Megnevezes}\nÁr: {Ar}";
        }
    }
}
