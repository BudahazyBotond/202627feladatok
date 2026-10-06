using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public class HibasFoglalasException : Exception
    {
        public HibasFoglalasException()
        :base("A kért időszakban a sporteszköz nem szabad!")
        {}
    }
}
