using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexer
{
    public class SakkTabla
    {
        readonly int[,] tabla = new int[8, 8];
        public SakkTabla()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if((i+j)%2 == 0)
                        tabla[i, j] = 0; //feher
                    else
                        tabla[i, j] = 1; //fekete
                }
            }
        }
        static int Oszlopindex(char oszlop)
        {
            return oszlop switch
            {
                'a' or 'A' => 0,
                'b' or 'B' => 1,
                'c' or 'C' => 2,
                'd' or 'D' => 3,
                'e' or 'E' => 4,
                'f' or 'F' => 5,
                'g' or 'G' => 6,
                'h' or 'H' => 7,
                _ => -1
            };
        }
        public int this[char oszlop, int sor]
        {
            get
            {
                if (Oszlopindex(oszlop) != -1 && sor > 0 && 9 > sor)
                    return tabla[Oszlopindex(oszlop), 8 - sor];
                else throw new IndexOutOfRangeException("rossz index");
            }
        }
    }
}
