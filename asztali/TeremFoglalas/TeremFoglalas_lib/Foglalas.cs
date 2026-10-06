using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremFoglalas_lib
{
    public class Foglalas : IFoglalas
    {
        public DateTime Kezdete {  get; init; }
        public string TanarAzonosito { get; init; }
        public string TeremAzonosito { get; init; }

        public int IdoTartamPercben { get; init; }
        public DateTime Vege => Kezdete.AddMinutes(IdoTartamPercben);
        public Foglalas(DateTime kezdoIdopont, int idoTartamPercben, 
            string teremAzonosito, string tanarAzonosito)
        {
            if(idoTartamPercben<15 || idoTartamPercben % 15 != 0)
            {
                throw new IdoTartamException();
            }
            Kezdete = kezdoIdopont;
            IdoTartamPercben = idoTartamPercben;
            TanarAzonosito = tanarAzonosito;
            TeremAzonosito = teremAzonosito;
        }
        public override string ToString()
        {
            return $"{Kezdete:yyyy.MM.dd} {Kezdete.TimeOfDay} " +
                $"- {Vege.TimeOfDay} {TanarAzonosito}";
        }
    }
}
