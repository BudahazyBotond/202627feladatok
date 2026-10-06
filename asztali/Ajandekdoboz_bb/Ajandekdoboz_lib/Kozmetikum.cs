using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_lib
{
    public sealed class Kozmetikum : Termek
    {
        public bool AllergenMentes { get; private set; }
        public bool AllatokonTesztelt { get; private set; }
        public Kozmetikum(string nev, int ar, bool allergenMentes, bool allatokonTesztelt)
            : base(nev, ar, TermekTipusok.TermekTipus.Kozmetikum)
        {
            AllergenMentes = allergenMentes;
            AllatokonTesztelt = allatokonTesztelt;
        }
        public override string ToString()
        {
            return base.ToString() + " | " + ExtraTul();
        }
        public override string ExtraTul()
        {
            string allergenMentesStr = AllergenMentes ? "Allergén mentes" : "Nem allergén mentes";
            string allatokonTeszteltStr = AllatokonTesztelt ? "Állatokon tesztelt" : "Nem állatokon tesztelt";
            return $" | {allergenMentesStr} | {allatokonTeszteltStr}";
        }
    }
}
