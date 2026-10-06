using System;
using System.Text;

namespace MesterEmberLib
{
    public sealed class VizvezetekSzerelo : MesterEmber
    {
        private int tapasztalatiEvek;

        public int TapasztalatiEvek => tapasztalatiEvek;

        public VizvezetekSzerelo(string nev, int tapasztalatiEvek)
            : base(nev, tapasztalatiEvek * 6000)
        {
            this.tapasztalatiEvek = tapasztalatiEvek;
        }

        public override bool MunkatVallal(int nap)
        {
            if (nap < 1 || nap > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(nap), "A nap sorszáma 1 és 31 között kell legyen!");
            }

            int elsoNap = nap - 1;
            int utolsoNap = nap + 1;

            if (elsoNap < 1 || utolsoNap > 31)
            {
                return false;
            }

            for (int i = elsoNap; i <= utolsoNap; i++)
            {
                if (!this[i])
                {
                    return false;
                }
            }

            for (int i = elsoNap; i <= utolsoNap; i++)
            {
                this[i] = false;
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Név: {nev}");
            sb.AppendLine($"Tapasztalati évek: {tapasztalatiEvek}");
            sb.AppendLine($"Napidíj: {napidij} Ft");
            sb.Append("Szabad napok: ");
            sb.AppendLine(string.Join(", ", FoglalhatoNapok()));
            return sb.ToString();
        }
    }
}