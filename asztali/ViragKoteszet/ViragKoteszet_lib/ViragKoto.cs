using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public sealed class ViragKoto : Dolgozo
    {
        public ViragKoto(int id, string nev) : base(id, nev)
        {

        }
        public override int Gyakorlottsag => 100;
        public override int MunkaraForditottIdo => feladatok.FeladatokElkeszetesiIdeje;
    }
}
