using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmazok_lib
{
    public class Lotto
    {
        private Random r = new Random();
        public RendezettHalmaz<int> Sorsolas(int max, int db)
        {
            var halmaz = new RendezettHalmaz<int>();
            while (halmaz.ElemMennyiseg < db)
            {
                halmaz.Hozzaad(r.Next(1, max + 1));
            }
            return halmaz;
        }
        public RendezettHalmaz<int> Jatek()
        {
            Console.WriteLine("Ötös (1), Hatos (2) vagy Skandináv (3)?");
            int jatek = int.Parse(Console.ReadLine()!);
            switch (jatek)
            {
                case 1:
                    return Sorsolas(90, 5);
                case 2:
                    return Sorsolas(45, 6);
                case 3:
                    return Sorsolas(35, 7);
                default:
                    Console.WriteLine("Érvénytelen választás!");
                    return Jatek();
            }
        }
    }
}
