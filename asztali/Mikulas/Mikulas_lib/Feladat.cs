using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_lib
{
    public class Feladat
    {
        const int MACIMUM_IDO = 8 * 60;
        public Jatek JatekTipus { get; init; }
        public int DarabSzam { get; init; }
        public Feladat(Jatek jatek, int darabszam)
        {
            JatekTipus = jatek;
            DarabSzam = darabszam;
            if (ElkeszitesiIdo > MACIMUM_IDO)
            {
                throw new TulSokFeladatException();
            }
        }
        public int ElkeszitesiIdo => JatekTipus.ElkeszitesiIdo * DarabSzam;
        public override string ToString()
        {
            return $"{JatekTipus}: {DarabSzam} db, elkészítési idő: {ElkeszitesiIdo} perc";
        }
    }
}
