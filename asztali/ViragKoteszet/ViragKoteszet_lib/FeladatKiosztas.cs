using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public static class FeladatKiosztas
    {
        public static void FeladatKiosztasa(Dolgozok dolgozok,Termekek termekek,
            int dolgozoId, int termekId)
        {
            try
            {
                dolgozok[dolgozoId].UjFeladatHozzaadasa(termekek[termekId]);
            }
            catch(Exception exception)
            {
                StreamWriter w1 = new StreamWriter("hibalista.txt");

                w1.WriteLine($"{dolgozoId};{termekId};{exception.Message}");
                w1.Close();
            }
        }
    }
}
