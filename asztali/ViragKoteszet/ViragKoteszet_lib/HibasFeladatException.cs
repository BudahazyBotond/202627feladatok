using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public class HibasFeladatException : Exception
    {
        public HibasFeladatException()
            : base("A feladathoz nincs elegendő tudása a gyakornoknak.")
        {
        }
    }
}
