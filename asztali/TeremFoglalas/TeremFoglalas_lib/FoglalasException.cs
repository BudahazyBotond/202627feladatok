using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremFoglalas_lib
{
    internal class FoglalasException : Exception
    {
        public FoglalasException() : 
            base("A kért időpontban a terem nem foglalható.")
        {
        }
    }
}
