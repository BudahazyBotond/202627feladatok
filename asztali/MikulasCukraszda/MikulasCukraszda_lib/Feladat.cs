using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_lib
{
    public class Feladat
    {
        const int MAXIDO = 8 * 60;
        public string SutemenyTipus { get; init; }
        public int Darab { get; init; }
        public Sutemeny Sutemeny { get; init; }
        public int ElkeszitesiIdo { get; init; }
        public Feladat(Sutemeny sutemeny, int darab)
        {
            Sutemeny = sutemeny;
            SutemenyTipus = sutemeny.Tipus;
            Darab = darab;
            ElkeszitesiIdo = sutemeny.ElkeszitesiIdo * Darab;
            if(ElkeszitesiIdo> MAXIDO)
            {
                throw new TulSokFeladatException();
            }
        }
        public override string ToString()
        {
            return $"{Sutemeny.Megnevezes}: {Darab}, elkészítési idő: {ElkeszitesiIdo}";
        }
    }
}
