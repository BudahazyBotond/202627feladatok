using System;
using System.Collections.Generic;
using System.Text;

namespace BarkacsAruhaz_lib
{
    public class SzerszamFactory
    {
        public static SzerszamElem Factory(string line, Szerszamok elerhetoSzerszamok)
        {
            string[] adatok = line.Split(';');
            if(adatok.Length == 1 )
            {
                return new EgyszeruSzerszam(elerhetoSzerszamok[adatok[0]]);
            }
            else
            {
                SzerszamKeszlet keszlet = new();
                foreach(string adat in adatok)
                {
                    keszlet += elerhetoSzerszamok[adat];
                }
                return keszlet;
            }
        }
    }
}
