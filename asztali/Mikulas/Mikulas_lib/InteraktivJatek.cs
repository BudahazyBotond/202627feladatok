using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_lib
{
    public class InteraktivJatek : Jatek
    {
        public InteraktivJatek(string azonosito, string tipus, string megnevezes, GyartasAdatok gyartas, IEnumerable<string> modulok)
            : base(azonosito, tipus, megnevezes, gyartas)
        {
            this.modulok = modulok.ToList();
        }
        private readonly List<string> modulok;
        public override int ElkeszitesiIdo => modulok.Sum(x => gyartasiAdatok[TipusMeghatarozo(x)]?.ElkeszitesiIdo ?? 0);
        static string TipusMeghatarozo(string modul) => (modul[0] == 'k') ? modul : modul[0].ToString();
    }
}
