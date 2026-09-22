using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_lib
{
    public abstract class TeasDoboz : IDoboz
    {
        public int DarabSzam { get; }
        public abstract int Ar { get; }
        public abstract string Nev { get; }

        internal TeasDoboz(int darabSzam)
        {
            DarabSzam = darabSzam;
        }

        public override string ToString()
        {
            return $"{Nev} ({Ar} Ft)";
        }
    }
}
