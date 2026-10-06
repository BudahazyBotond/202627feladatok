using System.Collections.Generic;

namespace MesterEmberLib
{
    public interface IFoglalhato
    {
        IEnumerable<int> FoglalhatoNapok();
        int SzabadnapokSzama { get; }
    }
}