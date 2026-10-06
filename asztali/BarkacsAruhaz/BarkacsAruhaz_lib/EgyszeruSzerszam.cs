using System;
using System.Collections.Generic;
using System.Text;

namespace BarkacsAruhaz_lib
{
    public sealed class EgyszeruSzerszam : SzerszamElem
    {
        public override string Nev {  get; }
        public override int Ar { get; }
        public Szerszam SzerSzam { get; init; }
        public EgyszeruSzerszam(Szerszam szerszam)
        {
            SzerSzam = szerszam;
            Nev = SzerSzam.Megnevezes;
            Ar = SzerSzam.Ar;
        }
    }
}
