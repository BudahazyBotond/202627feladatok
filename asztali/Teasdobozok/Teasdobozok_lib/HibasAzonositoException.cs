using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_lib
{
    internal class HibasAzonositoException : Exception
    {
        public HibasAzonositoException(int menny, string[] azonosito)
            :base($"A megadott filter azonosító nem létezik.({menny};{string.Join(";", azonosito)})"){ }
    }
}
