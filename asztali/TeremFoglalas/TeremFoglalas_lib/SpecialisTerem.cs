using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremFoglalas_lib
{
    public sealed class SpecialisTerem : Terem
    {
        public int TakaritasiIdo { get; init; }
        public SpecialisTerem(string teremAzonosito, int helyekSzama, int takaritasiIdo)
            : base(teremAzonosito, helyekSzama)
        {
            TakaritasiIdo = takaritasiIdo;
        }

        public override void IdopontFoglalas(Foglalas foglalas)
        {
            if(TeremOrarend.FoglaltE(foglalas.Kezdete, 
                foglalas.IdoTartamPercben + TakaritasiIdo))
            {
                throw new FoglalasException();
            }
            Foglalas takaritofoglalas = new Foglalas(
                foglalas.Kezdete.AddMinutes(foglalas.IdoTartamPercben),
                TakaritasiIdo,
                TeremAzonosito,
                "Takarító");
            TeremOrarend += foglalas;
            TeremOrarend += takaritofoglalas;
        }
        public override string ToString()
        {
            return $"{TeremAzonosito} (takarítási idő: {TakaritasiIdo} perc)" +
                $"\n{TeremOrarend}";
        }
    }
}
