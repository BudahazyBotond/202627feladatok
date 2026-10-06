using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzes_lib
{
    public interface IJarmuBerles
    {
        int SzemelyekSzama { get;}
        double Rakter { get; }
        int FizetendoAr(int ar);
        IEnumerable<int> KolcsonozhetoNapok();
    }
}
