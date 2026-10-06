using System;
using System.Collections.Generic;
using System.Text;

namespace BarkacsAruhaz_lib
{
    public class HibasSzerszamException : Exception
    {
        public HibasSzerszamException()
            :base("A megadott szerszámazonosító nem létezik.")
        {
        }
    }
}
