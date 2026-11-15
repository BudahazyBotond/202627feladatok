using System;
using System.Collections.Generic;
using System.Text;

namespace Lovaglas_lib
{
    public class Orarend
    {
        //ora_id;datum;kezdesi_ido;hossz;kepzes_id;szint_id;oktato_id;helyszin;letszam
        public int OraId { get; init; }
        public DateOnly Datum { get; init; }
        public TimeOnly KezdesiIdo { get; init; }
        public int Hossz { get; init; }
        public int KepzesId { get; init; }
        public int SzintId { get; init; }
        public int OktatoId { get; init; }
        public string Helyszin { get; init; }
        public int Letszam { get; init; }
        public Orarend(int oraId, DateOnly datum, TimeOnly kezdesiIdo, int hoszz,int kepzesId, int szintId, int oktatoId, string helyszin, int letszam)
        {
            OraId = oraId;
            Datum = datum;
            KezdesiIdo = kezdesiIdo;
            Hossz = hoszz;
            KepzesId = kepzesId;
            SzintId = szintId;
            OktatoId = oktatoId;
            Helyszin = helyszin;
            Letszam = letszam;
        }
    }
}
