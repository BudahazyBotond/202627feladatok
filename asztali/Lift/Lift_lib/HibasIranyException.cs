using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_lib
{
    public class HibasIranyException : Exception
    {
        public HibasIranyException()
            : base("Hibás irány!")
        {
        }
    }
}
