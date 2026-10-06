using System;
using System.Collections.Generic;
using System.Text;

namespace BarkacsAruhaz_lib
{
    public class Szerszamok
    {
        public List<Szerszam> SzeszamokList {  get; set; }
        public Szerszamok(IEnumerable<Szerszam> szerszamok)
        {
            SzeszamokList = szerszamok.ToList();
        }

        public Szerszam this[string azonosito] { 
            get {
                if (SzeszamokList.Find(x => x.Azonosito == azonosito) != null)
                {
                    return SzeszamokList.Find(x => x.Azonosito == azonosito)!;
                }
                else throw new HibasSzerszamException();
            } 
        }
        public IEnumerable<Szerszam> KeziSzerszamok()
        {
            return SzeszamokList.Where(x=>x.KeziSzerszam).OrderBy(x=>x.Megnevezes);
        } 
    }
}
