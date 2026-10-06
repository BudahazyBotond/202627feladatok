using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_lib
{
    public sealed class EgyszeruJatek : Jatek
    {
        public EgyszeruJatek(string azonosito, string tipus, string megnevezes, GyartasAdatok gyartasiAdatok)
            : base(azonosito, tipus, megnevezes, gyartasiAdatok)
        {
        }

        public override int ElkeszitesiIdo => gyartasiAdatok[Tipus]?.ElkeszitesiIdo ?? 0;
    }
}
