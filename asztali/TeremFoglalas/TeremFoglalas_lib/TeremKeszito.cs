using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremFoglalas_lib
{
    public static class TeremKeszito
    {
        //TeremTipus;TeremAzonosito;HelyekSzama;TakaritasiIdo

        public static Terem Teremkeszites(string fajlSor)
        {
            string[] adatok = fajlSor.Split(';');
            switch(adatok[0])
            {
                case "a":
                    return new AltalanosTerem(adatok[1], int.Parse(adatok[2]));
                case "s":
                    return new SpecialisTerem(adatok[1],
                        int.Parse(adatok[2]), int.Parse(adatok[3]));
                default:
                    throw new ArgumentException();
            };
        }
    }
}
