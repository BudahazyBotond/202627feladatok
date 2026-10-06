using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_lib
{
    public class Kezeles
    {
        public int KezelesId { get; init; }
        public int AlkalmazottId { get; init; }
        public int VendegId { get; init; }
        public string Datum { get; init; }
        public TimeOnly Idopont { get; init; }
        public int Ar { get; init; }
        public Kezeles(int kezelesId, int alkalmazottId, int vendegId, string datum, TimeOnly idopont, int ar)
        {
            KezelesId = kezelesId;
            AlkalmazottId = alkalmazottId;
            VendegId = vendegId;
            Datum = datum;
            Idopont = idopont;
            Ar = ar;
        }
    }
}
