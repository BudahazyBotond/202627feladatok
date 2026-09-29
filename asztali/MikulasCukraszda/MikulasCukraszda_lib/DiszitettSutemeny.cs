using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_lib
{
    public sealed class DiszitettSutemeny : Sutemeny
    {
        public IEnumerable<string> DiszitesAzonositok{ get; init; }
        public override int ElkeszitesiIdo
        {
            get
            {
                int osszIdo = 0;
                foreach(string azonosito in DiszitesAzonositok)
                {
                    osszIdo += KeszitesiAdatok[azonosito]!.ElkeszitesiIdo;
                }
                return osszIdo;

            }
        }
        public DiszitettSutemeny(string azonosito, string tipus, string megnevezes, KeszitesiAdatok keszitesiAdatok, IEnumerable<string> diszitesAzonositok) : base(azonosito, tipus, megnevezes, keszitesiAdatok)
        {
            DiszitesAzonositok = diszitesAzonositok;
        }
        public string TipusMeghetarozas(string azonosito)
        {
            if (azonosito.StartsWith("d")) return azonosito;
            else
            {
                return azonosito[0].ToString();
            }
        }
    }
}
