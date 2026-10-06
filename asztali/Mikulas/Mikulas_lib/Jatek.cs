using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_lib
{
    public abstract class Jatek : IJaterk
    {
        //Azonosito;Tipus;Megnevezes;ModulokAzonositoi
        protected Jatek(string azonosito, string tipus, string megnevezes, GyartasAdatok gyartasiAdatok)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            Megnevezes = megnevezes;
            this.gyartasiAdatok = gyartasiAdatok;
        }
        protected readonly GyartasAdatok gyartasiAdatok;
        public string Azonosito { get; init; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        public abstract int ElkeszitesiIdo { get; }
        public override string ToString()
        {
            return $"{Megnevezes}";
        }
    }
}
