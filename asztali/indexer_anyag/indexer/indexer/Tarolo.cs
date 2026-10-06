using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexer
{
    public class Tarolo
    {
        readonly int[] elemek;
        int n;

        public Tarolo(int elemszam = 1000)
        {
            elemek = new int[elemszam];
            n = 0;
        }
        public void Add(int elem)
        {
            elemek[n++] = elem;
        }
        public int Count => n;

        //public int this[int index] => index >=0 && index < n ? elemek[index] : throw new IndexOutOfRangeException("rossz index");

        public int this[int index]
        {
            get
            {
                return index >= 0 && index < n ? elemek[index] : throw new IndexOutOfRangeException("rossz index");
            }
            set {
                if (index >= 0 && index < n)
                    elemek[index] = value;
                else
                    throw new IndexOutOfRangeException("rossz index");
            }
        }
    }
}
