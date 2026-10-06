using System;
using System.Text;

namespace MesterEmberLib
{
    public sealed class Burkolo : MesterEmber
    {
        private string szakterulet;

        public string Szakterulet => szakterulet;

        public Burkolo(string nev, int napidij, string szakterulet) : base(nev, napidij)
        {
            if (szakterulet != "belső" && szakterulet != "külső")
            {
                throw new ArgumentException("A szakterület csak 'belső' vagy 'külső' lehet!");
            }
            this.szakterulet = szakterulet;
        }

        public override bool MunkatVallal(int nap)
        {
            if (nap < 1 || nap > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(nap), "A nap sorszáma 1 és 31 között kell legyen!");
            }

            if (!this[nap])
            {
                return false;
            }

            if (SzabadnapokSzama < 10)
            {
                throw new TulSokFoglaltsagException();
            }

            this[nap] = false;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Név: {nev}");
            sb.AppendLine($"Szakterület: {szakterulet}");
            sb.AppendLine($"Napidíj: {napidij} Ft");
            sb.Append("Szabad napok: ");
            sb.AppendLine(string.Join(", ", FoglalhatoNapok()));
            return sb.ToString();
        }
    }
}