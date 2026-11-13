using System;
using System.Collections.Generic;
using System.Text;

namespace Lovaglas_lib
{
    public class Szint
    {
        public int SzintId { get; init; }
        public string Megnevezes { get; init; }
        public string Kategoria { get; init; }
        public string Leiras { get; init; }
        public Szint(int szintId, string megnevezes, string kategoria, string leiras)
        {
            SzintId = szintId;
            Megnevezes = megnevezes;
            Kategoria = kategoria;
            Leiras = leiras;
        }
    }
}
