using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekdoboz_lib
{
    public class AjandekDoboz<T> where T : ITermek
    {
        public string CsomagNeve { get; set; }
        public int CsomagAra { get; private set; }
        public TermekTipusok.TermekTipus CsomagTipusa { get; set; }
        public List<T> Termekek { get; private set; }
        public AjandekDoboz(string csomagNeve, TermekTipusok.TermekTipus csomagTipusa)
        {
            CsomagNeve = csomagNeve;
            CsomagTipusa = csomagTipusa;
            Termekek = new List<T>();
            CsomagAra = 0;
        }
        public void UjTermek(T termek)
        {
            if (termek.Tipus == CsomagTipusa)
            {
                Termekek.Add(termek);
                CsomagAra += termek.Ar;
            }
            else
            {
                throw new ArgumentException("A termék nem tartozik a csomag tipusába.");
            }
        }
        public string TermekLista()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var termek in Termekek)
            {
                sb.AppendLine(termek.Nev + termek.ExtraTul());
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return $"{CsomagNeve} csomag tartalma:\n" +
                $"Típusa: {CsomagTipusa}\n" +
                $"Ára: {CsomagAra}\n" +
                $"Termékek száma: {Termekek.Count}\n" +
                $"Termékek:\n{string.Join(",", TermekLista())} \n";
        }
    }
}
