using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public interface IBerles
    {
        string SporteszkozID { get; }
        DateOnly BerlesKezdet{ get; }
        int NapokSzama{ get; }

    }
}
