using System;
using System.Collections.Generic;
using System.Text;

namespace ViragKoteszet_lib
{
    public interface ITermek
    {
        string Tipus { get; }
        string Megnevezes { get; }
        int ElkeszitesiIdo { get; }
        int Ar { get; }
    }
}
