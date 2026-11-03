using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szepseg_lib
{
    public class Kezeles
    {
        public int KezelesId { get; init; }
        public int AlkalmazottId { get; init; }
        public int VendegId { get; init; }
        public DateOnly Datum { get; init; }
        public TimeOnly Idopont { get; init; }
        public int Ar { get; init; }
        public Kezeles(int alkalmazottId, int kezelesId, int vendegId, DateOnly datum, TimeOnly idopont, int ar)
        {
            AlkalmazottId = alkalmazottId;
            KezelesId = kezelesId;
            VendegId = vendegId;
            Datum = datum;
            Idopont = idopont;
            Ar = ar;
        }

    }
}
