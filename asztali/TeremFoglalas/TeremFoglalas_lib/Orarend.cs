using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremFoglalas_lib
{
    public class Orarend
    {
        private readonly List<Foglalas> foglalasok 
            = new List<Foglalas>();
        public Orarend()
        {
        }

        public bool FoglaltE(DateTime kezdet,
            int idoTartam)
        {
            return foglalasok.Exists(x=>(x.Kezdete <= kezdet && x.Vege > kezdet) || 
            (x.Kezdete>kezdet && x.Kezdete<kezdet.AddMinutes(idoTartam)));
        }
        public static Orarend operator +(Orarend orarend, Foglalas foglalas)
        {
            if (orarend.FoglaltE(foglalas.Kezdete, foglalas.IdoTartamPercben))
            {
                throw new IdoTartamException();
            }

            var ujOrarend = new Orarend();
            ujOrarend.foglalasok.AddRange(orarend.foglalasok);
            ujOrarend.foglalasok.Add(foglalas);
            return ujOrarend;
        }
        public override string ToString()
        {
            return "Foglalt időpontok:\n" + string.Join("\n", foglalasok.
                OrderBy(x => x.Kezdete)
                .Select(x => x.ToString())
            );
        }
        public List<Foglalas> Foglalasok => foglalasok;
    }
}
