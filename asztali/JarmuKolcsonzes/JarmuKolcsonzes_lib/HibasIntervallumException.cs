using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzes_lib
{
    public class HibasIntervallumException : Exception
    {
        public HibasIntervallumException() : base("A megadott intervallum hibás!")
        {
        }
    }
}
