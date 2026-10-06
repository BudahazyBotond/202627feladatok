using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexer
{
    public class Romai
    {
        private readonly Dictionary<int, string> szamok = new()
        {
            {1,"I"},
            {2, "II"},
            {3, "III"},
            {4, "IV"},
            {5, "V"},
            {6, "VI"},
            {7, "VII"},
            {8, "VIII"},
            {9, "IX"},
            {10, "X"},
        };
        public string this[int i]
        {
            get
            {
                return szamok.TryGetValue(i, out string? value) ? value : "Nem ismerem ezt a számot";
            }
        }
    }
}
