using System;
using System.Collections.Generic;
using System.Text;

namespace ViragKoteszet_lib
{
    public class Termek : ITermek
    {
        public string Azonosito { get; init; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        private List<(Alapanyag alapanyag, int mennyiseg)> _alapanyagok;
        public int ElkeszitesiIdo { 
            get 
            {
                int ido = 0;
                foreach (var (alapanyag, mennyiseg) in _alapanyagok)
                {
                    ido += alapanyag.ElkesitesiIdo * mennyiseg;
                }
                return ido;
            } 
        }
        public int Ar { 
            get
            {
                int osszeg = 0;
                foreach(var (alapanyag, mennyiseg) in _alapanyagok)
                {
                    osszeg+= alapanyag.Ar * mennyiseg;
                }
                return osszeg;
            }
        }

        public Termek(string azonosito, string tipus, string megnevezes, List<(Alapanyag alapanyag, int mennyiseg)> alapanyagok)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            Megnevezes = megnevezes;
            _alapanyagok = alapanyagok;
        }
    }
}
