using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MesterEmberLib
{
    public abstract class MesterEmber : IFoglalhato
    {
        protected string nev;
        protected int napidij;
        protected bool[] foglaltsag;

        public string Nev => nev;
        public int Napidij => napidij;

        protected MesterEmber(string nev, int napidij)
        {
            this.nev = nev;
            this.napidij = napidij;
            foglaltsag = new bool[31];
            for (int i = 0; i < foglaltsag.Length; i++)
            {
                foglaltsag[i] = true;
            }
        }

        public IEnumerable<int> FoglalhatoNapok()
        {
            for (int i = 0; i < foglaltsag.Length; i++)
            {
                if (foglaltsag[i])
                {
                    yield return i + 1;
                }
            }
        }

        public int SzabadnapokSzama => foglaltsag.Count(n => n);

        public bool this[int index]
        {
            get
            {
                if (index < 1 || index > 31)
                {
                    throw new IndexOutOfRangeException($"A nap sorszáma 1 és 31 között kell legyen! Kapott: {index}");
                }
                return foglaltsag[index - 1];
            }
            protected set
            {
                if (index < 1 || index > 31)
                {
                    throw new IndexOutOfRangeException($"A nap sorszáma 1 és 31 között kell legyen! Kapott: {index}");
                }
                foglaltsag[index - 1] = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Név: {nev}");
            sb.AppendLine($"Napidíj: {napidij} Ft");
            sb.Append("Szabad napok: ");
            sb.AppendLine(string.Join(", ", FoglalhatoNapok()));
            return sb.ToString();
        }

        public abstract bool MunkatVallal(int nap);
    }
}