using System;
using System.Collections.Generic;
using System.Text;

namespace BarkacsAruhaz_lib
{
    public class SzerszamKeszlet : SzerszamElem
    {
        public List<Szerszam> Szerszamok = new();
        public override string Nev => $"Szeszámkészlet: {string.Join(", ", Szerszamok.Select(x=>x.Megnevezes))}";
        public override int Ar => Szerszamok.Sum(x=> x.Ar);
        public static SzerszamKeszlet operator +(SzerszamKeszlet szerszamKeszlet, Szerszam szerszam)
        {
            szerszamKeszlet.Szerszamok.Add(szerszam);
            return szerszamKeszlet;
        }
    }
}
