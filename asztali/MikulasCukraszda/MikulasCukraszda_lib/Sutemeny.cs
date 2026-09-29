using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_lib
{
    public abstract class Sutemeny : IEtel
    {
        public KeszitesiAdatok KeszitesiAdatok { get; init; }
        public string Azonosito { get; init; }

        public string Tipus { get; init; }

        public string Megnevezes { get; init; }

        public abstract int ElkeszitesiIdo { get; }
        public Sutemeny(string azonosito, string tipus, string megnevezes, KeszitesiAdatok keszitesiAdatok)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            Megnevezes = megnevezes;
            KeszitesiAdatok = keszitesiAdatok;
        }

        public override string ToString()
        {
            return Megnevezes;
        }
    }
}
