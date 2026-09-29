using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_lib
{
    public sealed class AlapSutemeny : Sutemeny
    {

        public override int ElkeszitesiIdo
        {
            get
            {
                return KeszitesiAdatok[Tipus]!.ElkeszitesiIdo;
                
            }
        }
        public AlapSutemeny(string azonosito, string tipus, string megnevezes, KeszitesiAdatok keszitesiAdatok) : base(azonosito, tipus, megnevezes, keszitesiAdatok)
        {
        }
    }
}
